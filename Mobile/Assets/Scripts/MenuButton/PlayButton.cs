using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayButton : ButtonBase
{
    [SerializeField] private Image image;
    
    protected override void OnClick()
    {
        image.enabled=true;
        audioSource.Play();
        StartCoroutine(FadeRoutine());

    }
    IEnumerator FadeRoutine(){

        while(!Mathf.Approximately(1,image.color.a)){
            float colorAlpha=Mathf.MoveTowards(image.color.a,1,Time.deltaTime);
            image.color=new Color(image.color.r,image.color.g,image.color.b,colorAlpha);
            yield return null;
        }
        Destroy(HowToPlay.Instance.gameObject);
        SceneManager.LoadScene(1);

    }

    
}
