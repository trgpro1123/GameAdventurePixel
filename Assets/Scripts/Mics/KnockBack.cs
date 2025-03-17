using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{

    public bool GettingKockBack{get;private set;}

    [SerializeField] float timeKnockBack;
    private Rigidbody2D rb;

    private void Awake() {
        rb=GetComponent<Rigidbody2D>();
    }
    
    public void GetKnockBack(Transform DamageSoure,float knockThrust){
        GettingKockBack=true;
        Vector2 diffirent=(transform.position-DamageSoure.position).normalized*knockThrust*rb.mass;
        rb.AddForce(diffirent,ForceMode2D.Impulse);
        StartCoroutine(KnockBackRoutine());
    }
    IEnumerator KnockBackRoutine(){
        yield return new WaitForSeconds(timeKnockBack);
        rb.velocity=Vector3.zero;
        GettingKockBack=false;
    }

}
