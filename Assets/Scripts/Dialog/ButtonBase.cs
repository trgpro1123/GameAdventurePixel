using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class ButtonBase : MonoBehaviour
{

    protected AudioSource audioSource;
    private Button button;
    protected virtual void Awake() {
        audioSource=GetComponent<AudioSource>();
    }
    protected virtual void Start()
    {
        LoadButton();
        AddOnClickEvent();
    }
    
    private void LoadButton(){
        if (this.button != null) return;
        this.button=GetComponent<Button>();
    }
    private void AddOnClickEvent(){
        this.button.onClick.AddListener(this.OnClick);
    }
    protected abstract void OnClick();
}
