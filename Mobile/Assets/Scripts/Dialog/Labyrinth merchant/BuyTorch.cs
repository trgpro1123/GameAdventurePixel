using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyTorch : ButtonBase
{
    [SerializeField] private AudioClip baseSound;
    [SerializeField] private AudioClip notEnoughSound;
    protected override void OnClick()
    {
        
        if(EconomyManager.Instance.GetScoreCoin()>=2){
            AudioSource.PlayClipAtPoint(baseSound,PlayerControler.Instance.transform.position,AudioManager.Instance.GetSFXVolme());
            if(!EventStory.Instance.openTorch) EventStory.Instance.OpenTorch();
            TorchPlayer.Instance.UpNumberTorch();
            EconomyManager.Instance.Buy(2);
        }
        else{
            audioSource.PlayOneShot(notEnoughSound);
        }
    }
}
