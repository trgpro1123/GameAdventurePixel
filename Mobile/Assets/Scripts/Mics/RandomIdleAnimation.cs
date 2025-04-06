using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomIdleAnimation : MonoBehaviour
{
    private Animator animator;

    private void Awake() {
        animator=GetComponent<Animator>();
    }
    void Start()
    {
        if(!animator){return;}
        AnimatorStateInfo state=animator.GetCurrentAnimatorStateInfo(0);
        animator.Play(state.fullPathHash,-1,Random.Range(0f,1f));

    }

    
}
