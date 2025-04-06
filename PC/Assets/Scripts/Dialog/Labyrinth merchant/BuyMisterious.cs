using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyMisterious : ButtonBase
{

    [SerializeField] private AudioClip baseSound;
    [SerializeField] private AudioClip notEnoughSound;
    private UnlockNewWeapon unlockNewWeapon;
    protected override void Start() {
        base.Start();
        if(!EventStory.Instance.openShortgun) this.gameObject.SetActive(false);
        unlockNewWeapon=GetComponent<UnlockNewWeapon>();
        
    }
    protected override void OnClick()
    {
        if(EconomyManager.Instance.GetScoreCoin()>=20){
            AudioSource.PlayClipAtPoint(baseSound,PlayerControler.Instance.transform.position,AudioManager.Instance.GetSFXVolme());
            EventStory.Instance.openShortgun=false;
            this.gameObject.SetActive(false);
            unlockNewWeapon.UnlockWeapon();
            EconomyManager.Instance.Buy(20);
        }
        else{
            audioSource.PlayOneShot(notEnoughSound);
        }
    }
}
