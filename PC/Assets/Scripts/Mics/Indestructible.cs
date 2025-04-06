using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indestructible : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        UbhBullet bullet = other.transform.GetComponentInParent<UbhBullet>();
        if(bullet){
            UbhObjectPool.instance.ReleaseBullet(bullet);
        }
    }
}
