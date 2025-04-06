using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChest : MonoBehaviour
{
    

    private BoxCollider2D boxCollider2D;
    private Animator animator;
    private bool hasOpen=false;
    private UnlockNewWeapon unlockNewWeapon;
    private AudioSource audioSource;

    readonly int OPEN_CHEST=Animator.StringToHash("Open");
    readonly int ATTACKED_CHEST=Animator.StringToHash("Attacked");

    private void Awake() {
        animator=GetComponent<Animator>();
        boxCollider2D=GetComponent<BoxCollider2D>();
        unlockNewWeapon=GetComponent<UnlockNewWeapon>();
        audioSource=GetComponent<AudioSource>();
    }



    private void OnTriggerEnter2D(Collider2D other) {
        if(hasOpen){
            return;
        }
        else{
            PlayerControler player=other.gameObject.GetComponent<PlayerControler>();
            if(player && KeyUI.Instance.hasKey){
                audioSource.Play();
                animator.SetTrigger(OPEN_CHEST);
                unlockNewWeapon.UnlockWeapon();
                hasOpen=true;
                KeyUI.Instance.HasKey(false);
            }else if(!player&&!KeyUI.Instance.hasKey){
                animator.SetTrigger(ATTACKED_CHEST);

            }

        }
    }
}
