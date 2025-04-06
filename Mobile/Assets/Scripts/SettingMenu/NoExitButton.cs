using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoExitButton : ButtonBase
{

    protected override void OnClick()
    {  
        Time.timeScale=1f;
        AudioSource.PlayClipAtPoint(audioSource.clip,PlayerControler.Instance.transform.position,AudioManager.Instance.GetSFXVolme());
        Time.timeScale=0f;
        SettingMenu.Instance.DisableSureExit();

        
    }
}
