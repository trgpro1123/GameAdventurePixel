using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : Singleton<PlayerHealth>
{
    public bool IsDeath{get;private set;}


    [SerializeField] private int maxHealth=3;
    [SerializeField] private float knockThrust=5f;
    [SerializeField] private float timeTakeDamgeAgain=1f;
    [SerializeField]  private float timeFreeze=2f;
    [SerializeField] [Range(0,100)] private float slowingRate=20f;
    

    private int currentHealth;



    private KnockBack knockBack;
    private Flash flash;
    private bool canTakeDamge=true;


    const string HEART_SLIDER="Hear Slider";
    const string VILLAGE="Village";

    readonly int DEATH_HASH=Animator.StringToHash("Death");
    private Slider healSlider;

    protected override void Awake() {
        base.Awake();
        knockBack=GetComponent<KnockBack>();
        flash=GetComponent<Flash>();
    }
    private void Start() {
        IsDeath=false;
        currentHealth=maxHealth;
        UpdateHealth();
        
    }

    private void OnCollisionStay2D(Collision2D other) {
        HealthEnemy enemy=other.gameObject.GetComponent<HealthEnemy>();
        HealthBoss healthBoss=other.gameObject.GetComponent<HealthBoss>();
        if(enemy||healthBoss){
            TakeDamage(1,other.transform);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        UbhBullet bullet = other.transform.GetComponentInParent<UbhBullet>(); 
        Projectile projectile=other.gameObject.GetComponent<Projectile>(); 
        // if((bullet&&PlayerControler.Instance.gameObject.GetComponent<CapsuleCollider2D>().IsTouching(other))||
        // (projectile&&PlayerControler.Instance.gameObject.GetComponent<CapsuleCollider2D>().IsTouching(other))){
        if(((bullet||projectile)&&PlayerControler.Instance.gameObject.GetComponent<CapsuleCollider2D>().IsTouching(other))){

            TakeDamage(1,other.transform);
            if(projectile){
                UbhObjectPool.instance?.ReleaseBullet(bullet);
            }
            Freeze();
        }
    }
    public void Freeze(){
        PlayerControler.Instance.Freeze(timeFreeze,slowingRate);
    }
    
    public void HealPlayer(){
        if(currentHealth<3){
            currentHealth+=1;
            UpdateHealth();

        }

    }
    

    public void TakeDamage(int damageAmuont,Transform hitTranform){
        if(!canTakeDamge){return;}
        
        ScreenShakeManager.Instance.ShakeScreen();
        knockBack.GetKnockBack(hitTranform,knockThrust);
        StartCoroutine(flash.FlashRoutine());
        canTakeDamge=false;
        currentHealth-=damageAmuont;
        StartCoroutine(DamageRecoveryRoutine());
        UpdateHealth();
        CheckIfPlayerDeath();
        


    }
    private void CheckIfPlayerDeath(){
        if(currentHealth<=0 && !IsDeath){
            IsDeath=true;
            Destroy(ActiveSword.Instance.gameObject);
            currentHealth=0;
            GetComponent<Animator>().SetTrigger(DEATH_HASH);
            StartCoroutine(DeathLoadSceenRoutine());
            
        }
    }
    private IEnumerator DeathLoadSceenRoutine(){
        
        yield return new WaitForSeconds(2);
        TorchPlayer.Instance.StopTorch();
        Destroy(gameObject);
        //yield return new WaitForSeconds(1);
        SceneManager.LoadScene(VILLAGE);
        MapManager.Instance.AciveMapFalse();
        MapManager.Instance.GetIndexScene(1);
        MapManager.Instance.ToggleAciveMap();
        
    }

    private void UpdateHealth(){
        if(healSlider==null){
            healSlider=GameObject.Find(HEART_SLIDER).GetComponent<Slider>();
        }
        healSlider.maxValue=maxHealth;
        healSlider.value=currentHealth;


    }
    private IEnumerator DamageRecoveryRoutine(){
        yield return new WaitForSeconds(timeTakeDamgeAgain);
        canTakeDamge=true;
    }
}
