using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NR2 : Singleton<NR2>
{
    protected override void Awake() {
        base.Awake();
        this.gameObject.transform.parent=MapManager.Instance.transform;
    }
    
}
