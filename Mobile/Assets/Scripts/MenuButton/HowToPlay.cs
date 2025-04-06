using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HowToPlay : Singleton<HowToPlay>
{

    private Animator animator;
    readonly int START_HASH=Animator.StringToHash("StartHTP");
    readonly int CLOSE_HASH=Animator.StringToHash("CloseHTP");
    readonly int IDLE_HASH=Animator.StringToHash("IdleHTP");
    
    protected override void Awake() {
        base.Awake();
        animator=GetComponent<Animator>();
    }

    public void StartHTP(){
        animator.SetTrigger(START_HASH);
    }
    public void EndHTP(){
        animator.SetTrigger(CLOSE_HASH);
    }
    public void PlayIdel(){
        animator.SetTrigger(IDLE_HASH);
    }
}
