using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSoundEffect : MonoBehaviour
{
    [SerializeField] private AudioClip fire;
    [SerializeField] private AudioClip dryFire;

    private AudioSource audioSource;

    private void Awake() {
        audioSource=GetComponent<AudioSource>();
    }
    public void PlayFire(){
        audioSource.PlayOneShot(fire);
    }
    public void PlayDryFire(){
        audioSource.PlayOneShot(dryFire);
    }
}
