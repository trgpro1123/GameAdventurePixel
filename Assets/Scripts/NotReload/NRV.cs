using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NRV : Singleton<NRV>
{
    protected override void Awake() {
        base.Awake();
        this.gameObject.transform.SetParent(MapManager.Instance.transform);
    }
    
}
