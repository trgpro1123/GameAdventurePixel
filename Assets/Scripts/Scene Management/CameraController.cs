using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraController : Singleton<CameraController>
{
    private CinemachineVirtualCamera cinemachineVirtualCamera;


    private void Start() {
        SetCinemachineVirtualCamera();
    }
    public void SetCinemachineVirtualCamera(){
        cinemachineVirtualCamera=FindObjectOfType<CinemachineVirtualCamera>();
        cinemachineVirtualCamera.Follow=PlayerControler.Instance.transform;
    }

}
