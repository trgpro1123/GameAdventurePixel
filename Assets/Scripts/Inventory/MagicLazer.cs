using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicLazer : MonoBehaviour
{
    [SerializeField] float LazerGrownTime=2f;    
    [SerializeField] private Material materialUpdate;

    private SpriteRenderer spriteRenderer;
    private CapsuleCollider2D capsuleCollider2D;
    private float range;
    private bool isGrowing=true;
    

    private void Awake() {
        spriteRenderer=GetComponent<SpriteRenderer>();
        capsuleCollider2D=GetComponent<CapsuleCollider2D>();
    }


    private void Start() {
        if(EventStory.Instance.updateStaff){
            spriteRenderer.material=materialUpdate;
        }
        LazerFaceMouse();
    }
    public void UpdateRangeLazer(float range){
        this.range=range;
        StartCoroutine(IncreaseLazerLenghtRoutine());

    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.GetComponent<Indestructible>()&&!other.isTrigger){
            isGrowing=false;
        }
    }
    IEnumerator IncreaseLazerLenghtRoutine(){
        float timePassed=0;

        while(spriteRenderer.size.x<range && isGrowing){
            timePassed+=Time.deltaTime;
            float lineT=timePassed/LazerGrownTime;
            spriteRenderer.size=new Vector2(Mathf.Lerp(1f,range,lineT),1f);

            capsuleCollider2D.size=new Vector2(Mathf.Lerp(1f,range,lineT),capsuleCollider2D.size.y);
            capsuleCollider2D.offset=new Vector2(Mathf.Lerp(1f,range,lineT)/2,capsuleCollider2D.offset.y);
            yield return null;
        }


        StartCoroutine(GetComponent<SpriteFade>().SlowFadeRoutine());
    }
    void LazerFaceMouse(){
        Vector3 mousePosition=Input.mousePosition;
        mousePosition=Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction=transform.position-mousePosition;
        transform.right=-direction;
    }
}
