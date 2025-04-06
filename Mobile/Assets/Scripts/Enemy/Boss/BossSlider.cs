using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossSlider : Singleton<BossSlider>
{

    public Slider slider;
    private void Start() {
        slider=GetComponent<Slider>();
        gameObject.SetActive(false);
    }

    
}
