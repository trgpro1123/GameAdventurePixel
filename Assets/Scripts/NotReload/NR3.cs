using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NR3 : Singleton<NR3>
{
    protected override void Awake() {
        base.Awake();
        this.gameObject.transform.parent=MapManager.Instance.transform;
    }
    
}
