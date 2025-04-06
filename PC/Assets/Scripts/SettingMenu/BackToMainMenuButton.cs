using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMainMenuButton : ButtonBase
{
    protected override void OnClick()
    {  
        audioSource.Play();
        SettingMenu.Instance.EnebleSureExit();
    }

    
}
