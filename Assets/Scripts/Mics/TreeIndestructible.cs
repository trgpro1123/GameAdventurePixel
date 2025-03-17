using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeIndestructible : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D other) {
        UbhBullet bullet = other.transform.GetComponentInParent<UbhBullet>();
        Projectile projectile=other.gameObject.GetComponent<Projectile>(); 
        CapsuleCollider2D capsuleCollider2D=this.gameObject.GetComponent<CapsuleCollider2D>();
        if((bullet||projectile)&&capsuleCollider2D.IsTouching(other)){
            if(bullet) UbhObjectPool.instance.ReleaseBullet(bullet);
            else if(projectile) Destroy(other.gameObject);
        }
        
    }
    
    
}
