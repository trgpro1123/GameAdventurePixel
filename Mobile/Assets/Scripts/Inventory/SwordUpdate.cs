using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordUpdate : MonoBehaviour
{
    private MonoBehaviour currenActiveWeapon=>ActiveSword.Instance.CurrentActiveWeapon;
    
    private void OnTriggerEnter2D(Collider2D other) {
        UbhBullet bullet = other.transform.GetComponentInParent<UbhBullet>(); 
        Projectile projectile=other.gameObject.GetComponent<Projectile>();
        if((currenActiveWeapon as IWeapon).GetWeaponInfo().isUpdate){
            if((bullet)){
                UbhObjectPool.instance.ReleaseBullet(bullet);
            }else if(projectile){
                Destroy(projectile.gameObject);
            }
        }
        
    }
}
