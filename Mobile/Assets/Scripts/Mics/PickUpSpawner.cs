using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSpawner : MonoBehaviour
{
    private enum RateDrop{
        LowLevel,
        MiddleLevel,
        HighLevel,
        Boss
    }
    [SerializeField] private GameObject goldCoin,heartGlobe,stamianGlobe;
    [SerializeField] RateDrop rateDrop;
    private bool received=false;


    
    public void DropItem(){
        if(received) return;
        received=true;
        int rate=1;
        switch(rateDrop){
            case RateDrop.LowLevel:
                rate=1;
            break;
            case RateDrop.MiddleLevel:  
                rate=2;
            break;
            case RateDrop.HighLevel:
                rate=3;
            break;
            default:
                rate=10;
            break;
        }
        int randomItem=Random.Range(1,5);
        switch(randomItem){
            case 1:
            int randomstamianGlobe=1;
                for(int i=0;i<randomstamianGlobe*rate;i++){
                    Instantiate(stamianGlobe,transform.position,Quaternion.identity);
                }
            break;
            case 2:
            int randomheartGlobe=1;
                for(int i=0;i<randomheartGlobe*rate;i++){
                    Instantiate(heartGlobe,transform.position,Quaternion.identity);
                }
            break;
            case 3:
            int randomCoin=Random.Range(2,4);
                for(int i=0;i<randomCoin*rate;i++){
                    Instantiate(goldCoin,transform.position,Quaternion.identity);
                }
            break;
        }
    }
}
