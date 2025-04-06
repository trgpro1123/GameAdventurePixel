using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFade : Singleton<UIFade>
{
    [SerializeField] Image fadeScene;
    [SerializeField] float speedFade;

    private IEnumerator fadeRoutine;
    private void Start() {
        fadeScene.color=new Color(fadeScene.color.r,fadeScene.color.g,fadeScene.color.b,1);
        FadeToClean();
    }

    public void FadeToBlack(){

        if(fadeRoutine!=null){
            StopCoroutine(fadeRoutine);
        }
        fadeRoutine=FadeRoutine(1);
        StartCoroutine(fadeRoutine);
    }

    public void FadeToClean(){
        if(fadeRoutine!=null){
            StopCoroutine(fadeRoutine);
        }
        fadeRoutine=FadeRoutine(0);
        StartCoroutine(fadeRoutine);

    }

    IEnumerator FadeRoutine(float target){

        while(!Mathf.Approximately(target,fadeScene.color.a)){
            float colorAlpha=Mathf.MoveTowards(fadeScene.color.a,target,speedFade*Time.deltaTime);
            fadeScene.color=new Color(fadeScene.color.r,fadeScene.color.g,fadeScene.color.b,colorAlpha);
            yield return null;
        }

    }
}
