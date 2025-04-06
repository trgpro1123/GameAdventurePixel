using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : ButtonBase
{


    protected override void OnClick()
    {
        audioSource.Play();
        Application.Quit();
    }
}
