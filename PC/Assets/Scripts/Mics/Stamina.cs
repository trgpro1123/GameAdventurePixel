using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stamina : Singleton<Stamina>
{
    
    public int CurrentStamina{get;private set;}


    [SerializeField] Sprite emptyStaminaImage,fullStaminaImage;
    [SerializeField] float timeRefreshStamina=3.5f;

    private int maxStamina;
    private int startingStamina=4;
    const string STAMINA_IMAGE="Stamina Container";
    private Transform staminaContainer;
    protected override void Awake() {
        base.Awake();
        maxStamina=startingStamina;
        CurrentStamina=startingStamina;

    }
    void Start()
    {
        staminaContainer=GameObject.Find(STAMINA_IMAGE).transform;
    }

    public void UseStamina(){
            if(CurrentStamina>0){
                CurrentStamina-=1;
                UpdateStamianImage();
            }
    }
    public void RefreshStamina(){
        if(CurrentStamina<maxStamina){
            CurrentStamina+=1;

        }
            UpdateStamianImage();
    }
    public void UpdateStamianImage(){

        for(int i=0;i<maxStamina;i++){

            if(i<=CurrentStamina-1){
                staminaContainer.GetChild(i).GetComponent<Image>().sprite=fullStaminaImage;
            }
            else{
                staminaContainer.GetChild(i).GetComponent<Image>().sprite=emptyStaminaImage;
            }
        }
        if(CurrentStamina<maxStamina){
            StopAllCoroutines();
            StartCoroutine(RefreshStaminaRoutine());
        }
    }
    private IEnumerator RefreshStaminaRoutine(){
        while(true){
            yield return new WaitForSeconds(timeRefreshStamina);
            RefreshStamina();
        }

    }








}
