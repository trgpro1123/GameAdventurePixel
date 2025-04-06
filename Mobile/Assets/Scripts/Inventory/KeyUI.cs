using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class KeyUI : Singleton<KeyUI>
{
    public bool hasKey;
    [SerializeField] private Image key;
    public void HasKey(bool setActiveKey){
        hasKey=setActiveKey;
        key.enabled=setActiveKey;
    }
}
