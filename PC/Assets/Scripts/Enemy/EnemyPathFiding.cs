using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathFiding : MonoBehaviour
{
    
    [SerializeField] private float moveSpeed;
    

    private Vector2 targetPositon;
    private Rigidbody2D myrigidbody;
    private KnockBack knockBack;
    private SpriteRenderer spriteRenderer;
    
    
    private void Awake() {
        myrigidbody=GetComponent<Rigidbody2D>();
        knockBack=GetComponent<KnockBack>();
        spriteRenderer=GetComponent<SpriteRenderer>();
        
    }
    
    

    private void FixedUpdate() {
        if(knockBack.GettingKockBack) {return;}
        myrigidbody.MovePosition(myrigidbody.position+targetPositon*
        (moveSpeed*Time.fixedDeltaTime));
        if(targetPositon.x<0){
            spriteRenderer.flipX=true;
        }
        else if(targetPositon.x>0) {
            spriteRenderer.flipX=false;
        }
    }

    public void getTargetPosition(Vector2 target){
        targetPositon=target;
    }
    public void StopMoving(){
        targetPositon=Vector3.zero;
    }
    public float GetMoveSpeed(){
        return moveSpeed;
    }
    

}
