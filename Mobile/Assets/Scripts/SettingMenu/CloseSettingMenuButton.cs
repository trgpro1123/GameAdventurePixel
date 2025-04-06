using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseSettingMenuButton : ButtonBase
{
    protected override void OnClick()
    {
        audioSource.Play();
        SettingMenu.Instance.CloseSettingMenu();
    }
}
