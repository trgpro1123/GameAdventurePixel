using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NRMazer : Singleton<NRMazer>
{
    protected override void Awake() {
        base.Awake();
        this.gameObject.transform.parent=MapManager.Instance.transform;
    }
    
    
}
