using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    [SerializeField] private ParticleSystem destroyVFX;
    private bool received=false;


    private AudioSource audioSource;
    private void Awake() {
        audioSource=GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(received) return;
        if(other.gameObject.GetComponent<DamageSoure>()){
            AudioSource.PlayClipAtPoint(audioSource.clip,PlayerControler.Instance.transform.position,AudioManager.Instance.GetSFXVolme());
            received=true;
            GetComponent<PickUpSpawner>().DropItem();
            ParticleSystem particleSystem= Instantiate(destroyVFX,transform.position,Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
