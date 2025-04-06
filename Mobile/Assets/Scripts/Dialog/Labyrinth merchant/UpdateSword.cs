using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateSword : ButtonBase
{
    [SerializeField] private AudioClip baseSound;
    [SerializeField] private AudioClip notEnoughSound;
    protected override void Start() {
        base.Start();
        if(EventStory.Instance.updateSword) this.gameObject.SetActive(false);
        
    }
    protected override void OnClick()
    {
        
        if(EconomyManager.Instance.GetScoreCoin()>=10){
            AudioSource.PlayClipAtPoint(baseSound,PlayerControler.Instance.transform.position,AudioManager.Instance.GetSFXVolme());
            EventStory.Instance.updateSword=true;
            ActiveInventory.Instance.ChangeActiveWeapon();
            this.gameObject.SetActive(false);
            EconomyManager.Instance.Buy(10);
        }
        else{
            audioSource.PlayOneShot(notEnoughSound);
        }
    }
}
