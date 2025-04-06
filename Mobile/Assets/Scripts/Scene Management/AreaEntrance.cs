using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaEntrance : MonoBehaviour
{
    [SerializeField] private string sceneTransition;




    private void Start() {
        if(sceneTransition==SceneManagement.Instance.sceneTransitionName){
            ObjectPool.Instance?.ClearBulletShell();
            AudioManager.Instance.ChangeMusic(SceneManager.GetActiveScene().buildIndex);
            MapManager.Instance.GetIndexScene(SceneManager.GetActiveScene().buildIndex);
            MapManager.Instance.ToggleAciveMap();

            PlayerControler.Instance.transform.position=this.transform.position;
            CameraController.Instance.SetCinemachineVirtualCamera();
            UIFade.Instance.FadeToClean();
        }
    }
}
