using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaExit : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;
    [SerializeField] private string sceneTransitionName;


    private float waitToLoadTime=1f;
    private void Awake() {

        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.GetComponent<PlayerControler>()){
            SceneManagement.Instance.SetSceneTransitionName(sceneTransitionName);
            UIFade.Instance.FadeToBlack();
            StartCoroutine(LoadSceneRoutine());

        }
    }

    IEnumerator LoadSceneRoutine(){
        while(waitToLoadTime>=0){
            waitToLoadTime-=Time.deltaTime;
            yield return null;
        }
            MapManager.Instance.AciveMapFalse();
            SceneManager.LoadScene(sceneToLoad);
    }
}
