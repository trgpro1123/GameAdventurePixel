using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class TransparentDetection : MonoBehaviour
{
    [Range(0,1)]
    [SerializeField] private float transparencyAmount=0.7f;
    [SerializeField] private float fadeTime=0.5f;


    SpriteRenderer spriteRenderer;
    Tilemap tilemap;


    private void Awake() {
        spriteRenderer=GetComponent<SpriteRenderer>();
        tilemap=GetComponent<Tilemap>();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.GetComponent<PlayerControler>()){
            if(spriteRenderer){
                StartCoroutine(FadeRoutine(spriteRenderer,fadeTime,spriteRenderer.color.a,transparencyAmount));
            }
            else if(tilemap){
                StartCoroutine(FadeRoutine(tilemap,fadeTime,tilemap.color.a,transparencyAmount));

            }
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.GetComponent<PlayerControler>()){
            if(spriteRenderer){
                StartCoroutine(FadeRoutine(spriteRenderer,fadeTime,spriteRenderer.color.a,1));
            }
            else if(tilemap){
                StartCoroutine(FadeRoutine(tilemap,fadeTime,tilemap.color.a,1));

            }
        }
        
    }
    private void Update() {
        
    }
    private IEnumerator FadeRoutine(SpriteRenderer spriteRenderer,float fadeTime,float startValue,float transparency){
        float elapsedTime=0;
        while(elapsedTime<fadeTime){
            elapsedTime+=Time.deltaTime;
            float newAphal=Mathf.Lerp(startValue,transparency,elapsedTime/fadeTime);
            spriteRenderer.color=new Color(spriteRenderer.color.r,spriteRenderer.color.g,spriteRenderer.color.b,newAphal);
            yield return null;
        }
    }
    private IEnumerator FadeRoutine(Tilemap tilemap,float fadeTime,float startValue,float transparency){
        float elapsedTime=0;
        while(elapsedTime<fadeTime){
            elapsedTime+=Time.deltaTime;
            float newAphal=Mathf.Lerp(startValue,transparency,elapsedTime/fadeTime);
            tilemap.color=new Color(tilemap.color.r,tilemap.color.g,tilemap.color.b,newAphal);
            yield return null;
        }
    }

    

    










}
