using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    [SerializeField] private Image image;

    private void Start() {
        image.color=new Color(image.color.r,image.color.g,image.color.b,1);
        StartCoroutine(FadeToClean());
    }
    IEnumerator FadeToClean(){

        while(!Mathf.Approximately(0,image.color.a)){
            float colorAlpha=Mathf.MoveTowards(image.color.a,0,Time.deltaTime);
            image.color=new Color(image.color.r,image.color.g,image.color.b,colorAlpha);
            yield return null;
        }
        image.enabled=false;

    }
}
