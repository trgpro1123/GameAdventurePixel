using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueGrapeLandSplatter : MonoBehaviour
{
    
    private SpriteFade spriteFade;


    private void Awake() {
        spriteFade=GetComponent<SpriteFade>();
    }
    void Start()
    {

        StartCoroutine(spriteFade.SlowFadeRoutine());

    }
    private void OnTriggerStay2D(Collider2D other) {
        PlayerHealth playerHealth=other.gameObject.GetComponent<PlayerHealth>();
        playerHealth?.TakeDamage(1,other.transform);
        playerHealth?.Freeze();
    }
    // private void OnTriggerStayD(Collider2D other) {
        
    // }

    // private void DisableCollider(){
    //     GetComponent<CapsuleCollider2D>().enabled=false;
    // }
}
