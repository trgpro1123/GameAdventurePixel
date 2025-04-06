using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeftDestroy : MonoBehaviour
{

    private ParticleSystem pt;

    private void Awake() {
        pt=GetComponent<ParticleSystem>();
    }

    private void Update() {
        if(pt &&!pt.IsAlive()){
            DestroySelf();
        }
    }
    public void DestroySelf(){
        Destroy(gameObject);
    }
}
