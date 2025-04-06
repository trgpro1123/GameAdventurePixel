using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSettingMenuButton : ButtonBase
{
    protected override void OnClick()
    {
        audioSource.Play();
    }
}
