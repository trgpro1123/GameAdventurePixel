using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{

    private enum PickUpType{
        goldCoin,
        heartGlobe,
        stamianGlobe,
    }


    [SerializeField] PickUpType pickUpType;
    [SerializeField] private float pickUpDistance=5f;
    [SerializeField] private float speedCoin=2f;
    [SerializeField] private float speedMoveToPlayerPerSec=0f;
    [SerializeField] private AnimationCurve animationCurve;
    [SerializeField] private float heightY=2f;
    [SerializeField] private float popDuration=0.5f;

    private Vector3 moveDir;
    private Rigidbody2D rb;
    private void Awake() {
        rb=GetComponent<Rigidbody2D>();
    }

    private void Start() {
        StartCoroutine(AnimaCurveRoutine());
    }
    void Update()
    {
        Vector3 playerPos=PlayerControler.Instance.transform.position;

        if(Vector3.Distance(transform.position,playerPos)<pickUpDistance){
            moveDir=(playerPos-transform.position).normalized;
            speedCoin+=speedMoveToPlayerPerSec;
        }
        else{
            moveDir=Vector3.zero;
            speedCoin=0;
        }
        
    }
    private void FixedUpdate() {
        rb.velocity=moveDir*speedCoin*Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.GetComponent<PlayerControler>()){
            DetectPickUpType();
            Destroy(gameObject);
        }
    }

    private IEnumerator AnimaCurveRoutine(){
        Vector2 startPoint=transform.position;
        float randomX=transform.position.x+Random.Range(-2f,2f);
        float randomY=transform.position.y+Random.Range(-1f,1f);
        Vector2 endPoint=new Vector2(randomX,randomY);
        float timePassed=0f;
        while(timePassed<popDuration){
            timePassed+=Time.deltaTime;
            float linearT=timePassed/popDuration;
            float heightT=animationCurve.Evaluate(linearT);
            float height=Mathf.Lerp(0f,heightY,heightT);

            transform.position=Vector2.Lerp(startPoint,endPoint,linearT)+new Vector2(0f,height);


            yield return null;
        }
    } 

    private void DetectPickUpType(){
        switch(pickUpType){
            case PickUpType.goldCoin:
                EconomyManager.Instance.PickUpCoin();
            break;
            case PickUpType.heartGlobe:
                PlayerHealth.Instance.HealPlayer();
            break;
            case PickUpType.stamianGlobe:
                Stamina.Instance.RefreshStamina();
            break;
        }
    }
}
