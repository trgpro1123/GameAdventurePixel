using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedbushDestructible : MonoBehaviour
{
    [SerializeField] private Transform enemiesObject;
    [SerializeField] private ParticleSystem destroyVFX;
    private bool received=false;


    private AudioSource audioSource;
    private MonoBehaviour currenActiveWeapon=>ActiveSword.Instance.CurrentActiveWeapon;
    private void Awake() {
        audioSource=GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(received) return;
        if(other.gameObject.GetComponent<DamageSoure>()&&enemiesObject.childCount==0&&
        (currenActiveWeapon as IWeapon).GetWeaponInfo().isUpdate){
            AudioSource.PlayClipAtPoint(audioSource.clip,PlayerControler.Instance.transform.position,AudioManager.Instance.GetSFXVolme());
            received=true;
            GetComponent<PickUpSpawner>().DropItem();
            ParticleSystem particleSystem= Instantiate(destroyVFX,transform.position,Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
