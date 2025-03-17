using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBoss : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private int healthTransForm=100;
    [SerializeField] private AudioClip deathSFX;
    [SerializeField] private GameObject shadown;
    [SerializeField] private GameObject lightTransform;
    [SerializeField] private SpawnEmenies spawnEmenies;
    [SerializeField] public int revivalTime=20;

    private PickUpSpawner pickUpSpawner;
    private Animator myAnimator;
    readonly int DIE_HASH=Animator.StringToHash("Die");
    private int currentHealth;
    private Flash flash;
    private bool canTakeDamge=true;
    private CapsuleCollider2D capsuleCollider2D;
    private bool transForm=false;
    private StatusChange statusChange;



    

    private void Awake() {
        flash=GetComponent<Flash>();
        pickUpSpawner=GetComponent<PickUpSpawner>();
        myAnimator=GetComponent<Animator>();
        capsuleCollider2D=GetComponent<CapsuleCollider2D>();
        statusChange=GetComponent<StatusChange>();
        lightTransform.SetActive(false);
    }

    void Start()
    {
        statusChange.StopShotRoutine();
        currentHealth=health;
        BossSlider.Instance.gameObject.SetActive(true);
        BossSlider.Instance.slider.maxValue=currentHealth;
        BossSlider.Instance.slider.value=currentHealth;
    }
    private void OnDestroy() {
        try{BossSlider.Instance.gameObject.SetActive(false); spawnEmenies.StopAllCoroutines();}
        catch (System.Exception){}
    }


    public void TakeDamage(int damage){
        
        if(canTakeDamge){

            currentHealth-=damage;
            BossSlider.Instance.slider.value=currentHealth;
            CanTransForm();
            StartCoroutine(DieRoutine());
        }
        
    }
    public void HealBoss(int heal){

        currentHealth+=heal;
        BossSlider.Instance.slider.value=currentHealth;
        CombackForm1();
        
    }
    private void CombackForm1(){
        if(currentHealth>=healthTransForm){
            lightTransform.SetActive(false);
            statusChange.StopShotRoutine();
            statusChange.AddShotForm1();
            transForm=false;
            statusChange.StartShotRoutine();
        }
        

    }
    private void CanTransForm(){
        if((currentHealth<=healthTransForm)&&transForm==false){
            lightTransform.SetActive(true);
            statusChange.AddShotForm2();
            statusChange.StopShotRoutine();
            transForm=true;
            statusChange.StartShotRoutine();
            spawnEmenies.Spawn();

        }
    }

    IEnumerator DieRoutine(){
        StartCoroutine(flash.FlashRoutine());
        yield return new WaitForSeconds(flash.GetTimeDuratinFlash());
        Die();
        }


    private void Die(){
        if(currentHealth<=0){
            AudioManager.Instance.ChangeBaseMusic();
            canTakeDamge=false;
            AudioSource.PlayClipAtPoint(deathSFX,PlayerControler.Instance.transform.position,AudioManager.Instance.GetSFXVolme());
            capsuleCollider2D.enabled=false;
            lightTransform.SetActive(false);
            statusChange.StopShotRoutine();
            myAnimator.SetTrigger(DIE_HASH);
            pickUpSpawner.DropItem();
            Destroy(shadown);
            Destroy(gameObject,1.5f);
            EventStory.Instance.finishBoss=true;
            BossSlider.Instance.gameObject.SetActive(false);
            
        }
        
    }
    public int GetCurrentHealth(){
        return currentHealth;
    }
    public int GetHealthTransForm(){
        return healthTransForm;
    }

}
