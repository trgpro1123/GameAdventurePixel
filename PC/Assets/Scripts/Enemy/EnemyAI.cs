using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    [SerializeField] MonoBehaviour enemyType;
    [SerializeField] float timeChangePosition;
    [SerializeField] float attackCooldown=2f;
    [SerializeField] float attackRange=20f;
    [SerializeField] bool stopMovingWhileAttacking=false;


    private enum State{
        roaming,
        attacking
    }
    private State state;
    private EnemyPathFiding enemyPathFiding;
    private Vector2 roamPosition;
    private float timeRoaming=0f;
    private bool canAttack=true;
    private void Awake() {
        
        enemyPathFiding=GetComponent<EnemyPathFiding>();
        state=State.roaming;
    }

    
    void Start()
    {
        roamPosition=GetRandomPosition();
    }
    private void OnDisable() {
        canAttack=true;
        state=State.roaming;
    }
    private void Update() {
        MovementStateControl();
    }


    private void MovementStateControl(){
        switch(state){
            default:
            case State.roaming:
                Roaming();

                break;
            case State.attacking:

                Attacking();
                break;
        }
    }

    private void Roaming(){
        timeRoaming+=Time.deltaTime;
        enemyPathFiding.getTargetPosition(roamPosition);

        if(Vector2.Distance(transform.position,PlayerControler.Instance.transform.position)<attackRange)
            state=State.attacking;

        if(timeRoaming>timeChangePosition){
            roamPosition=GetRandomPosition();
        }

    }
    private void Attacking(){
        
        if ((Vector2.Distance(transform.position, PlayerControler.Instance.transform.position) > attackRange)||PlayerHealth.Instance.IsDeath)
        {
            state = State.roaming;
        }

        if(canAttack&&attackRange!=0){
            canAttack=false;
            (enemyType as IEnemy).Attack();

            if(stopMovingWhileAttacking){
                enemyPathFiding.StopMoving();
            }else{
                enemyPathFiding.getTargetPosition(roamPosition);
            }
            StartCoroutine(AttackCooldownRoutine());

        }

    }
    private IEnumerator AttackCooldownRoutine(){
        yield return new WaitForSeconds(attackCooldown);
        canAttack=true;
    }
    
    private Vector2 GetRandomPosition(){
        timeRoaming=0f;
        return new Vector2(Random.Range(-1f,1f),Random.Range(-1f,1f)).normalized;
    }
}