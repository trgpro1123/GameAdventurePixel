using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
public class FlashLight : MonoBehaviour
{

    [SerializeField] private float lightOnDelay = 0.01f, lightOffDelay = 0.01f;


    [SerializeField] private Light2D lightTarget;

    private void Start() {
        lightTarget.enabled=false;
    }

    public void Muzzle(){
        StopMuzzle();
        StartCoroutine(MuzzelRoutine(lightOnDelay, true, () => StartCoroutine(MuzzelRoutine(lightOffDelay, false))));
    }
    private IEnumerator MuzzelRoutine(float time, bool result, Action FinishCallback = null){
        yield return new WaitForSeconds(time);
        lightTarget.gameObject.GetComponent<Light2D>().enabled = result;
        FinishCallback?.Invoke();
    }
    private void StopMuzzle(){
        StopAllCoroutines();
        lightTarget.enabled=false;

    }
}
