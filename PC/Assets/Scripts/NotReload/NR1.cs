using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NR1 : Singleton<NR1>
{

    protected override void Awake() {
        base.Awake();
        this.gameObject.transform.parent=MapManager.Instance.transform;
    }
    
    
}
