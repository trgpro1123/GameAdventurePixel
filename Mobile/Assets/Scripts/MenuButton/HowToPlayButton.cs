using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToPlayButton : ButtonBase
{
    protected override void OnClick()
    {
        audioSource.Play();
        HowToPlay.Instance.StartHTP();

    }
}
