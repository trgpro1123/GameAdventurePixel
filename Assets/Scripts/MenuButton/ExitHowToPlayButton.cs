using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitHowToPlayButton : ButtonBase
{
    protected override void OnClick()
    {
        audioSource.Play();
        HowToPlay.Instance.EndHTP();
    }
}
