using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YesExitButton : ButtonBase
{
    protected override void OnClick()
    {
        audioSource.Play();
        SettingMenu.Instance.BackToMainMenu(); 
    }
}
