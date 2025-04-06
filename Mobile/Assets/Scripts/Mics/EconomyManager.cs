using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EconomyManager : Singleton<EconomyManager>
{
    

    private TMP_Text goldText;
    private int scoreCoin;
    const string COIN_AMOUNT_TEXT="Gold Amount Text";

    private void Start() {
        scoreCoin=10;
        goldText=GameObject.Find(COIN_AMOUNT_TEXT).GetComponent<TMP_Text>();
        goldText.text=scoreCoin.ToString("D4");

    }
    public void UpdateGoldAmount(){
        goldText.text=scoreCoin.ToString("D4");
    }
    public void PickUpCoin(){
        scoreCoin++;
        UpdateGoldAmount();
    }
    public int GetScoreCoin(){
        return scoreCoin;
    }
    public void PlusCoin(int amount){
        scoreCoin+=amount;
        UpdateGoldAmount();
    }
    public void Buy(int amount){
        scoreCoin-=amount;
        UpdateGoldAmount();
    }









}
