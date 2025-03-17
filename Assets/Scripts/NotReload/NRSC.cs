using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NRSC : Singleton<NRSC>
{
    protected override void Awake() {
        base.Awake();
        this.gameObject.transform.parent=MapManager.Instance.transform;
    }
    
}
