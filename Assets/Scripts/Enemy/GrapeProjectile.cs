using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapeProjectile : MonoBehaviour
{
    
    [SerializeField] AnimationCurve animationCurve;
    [SerializeField] float heightY;
    [SerializeField] float duration;
    [SerializeField] GameObject grapeProjectileShadown;
    [SerializeField] GameObject slatterPrefab;

    void Start()
    {
        
        GameObject projectileShadown=Instantiate(grapeProjectileShadown,transform.position+new Vector3(0f,-0.3f,0f),Quaternion.identity);
        Vector3 playerPos=PlayerControler.Instance.transform.position;
        Vector3 grapeShadownStartPos=projectileShadown.transform.position;
        StartCoroutine(ProjecttileCurveRoutine(transform.position,playerPos));
        StartCoroutine(MoveProjectileShadownRoutine(projectileShadown,grapeShadownStartPos,playerPos));

        
    }

    
    IEnumerator ProjecttileCurveRoutine(Vector3 startPosition,Vector3 endPosition){
        float timePassed=0f;
        while(timePassed<duration){
            timePassed+=Time.deltaTime;
            float linearT=timePassed/duration;
            float heightT=animationCurve.Evaluate(linearT);
            float height=Mathf.Lerp(0f,heightY,heightT);

            transform.position=Vector2.Lerp(startPosition,endPosition,linearT)+new Vector2(0f,height);


            yield return null;
        }
        Instantiate(slatterPrefab,transform.position,Quaternion.identity);
        Destroy(gameObject);
    }
    IEnumerator MoveProjectileShadownRoutine(GameObject shadownProjectile,Vector3 startPosition,Vector3 endPosition){
        float timePassed=0f;
        while(timePassed<duration){
            timePassed+=Time.deltaTime;
            float linearT=timePassed/duration;
            shadownProjectile.transform.position=Vector2.Lerp(startPosition,endPosition,linearT);
            yield return null;
        }
        Destroy(shadownProjectile);
    }
    

}
