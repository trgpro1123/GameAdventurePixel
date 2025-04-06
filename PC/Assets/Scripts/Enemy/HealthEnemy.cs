using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthEnemy : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] float forceKnockBack=15f;
    [SerializeField] private ParticleSystem deathVFX;
    [SerializeField]  private float timeFreeze=2f;
    [SerializeField] [Range(0,100)] private float slowingRate=20f;
    private PickUpSpawner pickUpSpawner;
    private int currentHealth;
    private KnockBack knockBack;
    private Flash flash;
    private IEnumerator freezeRoutine;
    private SpriteRenderer spriteRenderer;
    private EnemyPathFiding enemyPathFiding;
    private float moveSpeed;
    
    

    private void Awake() {
        knockBack=GetComponent<KnockBack>();
        flash=GetComponent<Flash>();
        pickUpSpawner=GetComponent<PickUpSpawner>();
        spriteRenderer=GetComponent<SpriteRenderer>();
        enemyPathFiding=GetComponent<EnemyPathFiding>();
    }

    void Start()
    {
        currentHealth=health;
    }


    public void TakeDamage(int damage){
        health-=damage;
        knockBack.GetKnockBack(PlayerControler.Instance.transform,forceKnockBack);
        StartCoroutine(DieRoutine());
    }

    IEnumerator DieRoutine(){
        StartCoroutine(flash.FlashRoutine());
        yield return new WaitForSeconds(flash.GetTimeDuratinFlash());
        Die();
        }

    private void Die(){
        if(health<=0){
            Instantiate(deathVFX,transform.position,Quaternion.identity);
            Destroy(gameObject);
            pickUpSpawner.DropItem();
            
        }
        
    }
    public void NormalState(){
        spriteRenderer.color=Color.white;
        moveSpeed=enemyPathFiding.GetMoveSpeed();
    }
    public void Freeze(){
        if(freezeRoutine!=null){
            StopCoroutine(freezeRoutine);
            NormalState();
        }
        freezeRoutine=FreezeAttackRoutine(timeFreeze,slowingRate);
        StartCoroutine(freezeRoutine);
    }
    IEnumerator FreezeAttackRoutine(float timeFreeze,float rate){
        spriteRenderer.color=Color.blue;
        float moveAttacked=enemyPathFiding.GetMoveSpeed()-(rate/100)*enemyPathFiding.GetMoveSpeed();
        moveSpeed=moveAttacked;
        yield return new WaitForSeconds(timeFreeze);
        spriteRenderer.color=Color.white;
        moveSpeed=enemyPathFiding.GetMoveSpeed();

    }
}
