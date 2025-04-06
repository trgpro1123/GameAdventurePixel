using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : Singleton<AudioManager>
{
    [SerializeField] private AudioClip bossFightingMusic;
    [SerializeField] private AudioClip baseMusic;
    [SerializeField] private AudioClip darkMusic;

    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider sliderMusic;
    [SerializeField] private Slider sliderSFX;
    
    

    
    private AudioSource audioSource;
    protected override void Awake()
    {
        base.Awake();
        audioSource=GetComponent<AudioSource>();
    }

    private void Start() {
        // audioSource=GetComponent<AudioSource>();
        sliderMusic.value=0.5f;
        sliderSFX.value=0.5f;
        
        audioMixer.SetFloat("Music",Mathf.Lerp(-40f,20,sliderMusic.value));
        audioMixer.SetFloat("SFX",Mathf.Lerp(-40f,20,sliderMusic.value));
        audioSource.Play();
    }
    public void ChangeVolumeMusic(){
        float volume=sliderMusic.value;
        audioMixer.SetFloat("Music",Mathf.Lerp(-40f,20,volume));
    }
    public void ChangeVolumeSFX(){
        float volume=sliderSFX.value;
        audioMixer.SetFloat("SFX",Mathf.Lerp(-40f,20,volume));
    }
    public void ChangeBaseMusic(){
        audioSource.clip=baseMusic;
        audioSource.Play();
    }
    public void ChangeMusic(int scene){
        if(scene==7&&!EventStory.Instance.finishBoss){
            audioSource.clip=bossFightingMusic;
            audioSource.Play();
        }
        else if(scene==8){
            audioSource.clip=darkMusic;
            audioSource.Play();
        }
        else if(audioSource.clip==bossFightingMusic||audioSource.clip==darkMusic){
            audioSource.clip=baseMusic;
            audioSource.Play();
        }
    }
    public float GetSFXVolme(){
        return sliderSFX.value;
    }
    public float GetMusicVolme(){
        return sliderMusic.value;
    }
   
}
