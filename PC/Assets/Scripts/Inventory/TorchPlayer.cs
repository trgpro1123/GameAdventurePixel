using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TorchPlayer : Singleton<TorchPlayer>
{
    [SerializeField] private GameObject Torch;
    [SerializeField] private Slider timeTorch;
    [SerializeField] private TMP_Text textNumberTorch;
    [SerializeField] private float timer;


    private float currentTime;
    private bool running=false;

    private int numberTorch=0;
    private GameObject torchPref;

    private void Start() {
        
        currentTime=0;
        timeTorch.maxValue=timer;
        timeTorch.value=currentTime;
    }

    private void Update() {
        if(running) MouseFollowWithOffset();
        if(Input.GetKeyDown(KeyCode.Q)&&!running){
            
            StartTorch();
        }
        else if(Input.GetKeyDown(KeyCode.Q)&&running){
            StopTorch();
        }
    }

    private void StartTorch(){
        running=true;
        torchPref=Instantiate(Torch,PlayerControler.Instance.transform.position,Quaternion.identity);
        torchPref.transform.SetParent(PlayerControler.Instance.transform);
        torchPref.gameObject.SetActive(true);
        StartCoroutine(TorchRoutine());

        
    }
    public void StopTorch(){
        StopAllCoroutines();
        running=false;
        Destroy(torchPref);
    }

    private IEnumerator TorchRoutine(){
        while(running){
            if(currentTime>0){
                timeTorch.value=currentTime;
                currentTime-=Time.deltaTime;
            }
            else if(numberTorch>=1){
                numberTorch--;
                textNumberTorch.text="x"+numberTorch.ToString();
                currentTime=timer;
            }
            else if(numberTorch==0){
                textNumberTorch.text="x"+numberTorch.ToString();
                StopTorch();
            } 
            yield return null;
        }
  
    }
    void MouseFollowWithOffset(){
        Vector2 positionMose=Input.mousePosition;
        Vector3 positionWorld=Camera.main.WorldToScreenPoint(PlayerControler.Instance.transform.position);
        if(positionMose.x<positionWorld.x){
            torchPref.transform.position=PlayerControler.Instance.transform.position+new Vector3(-0.72f,0.67f,0);
        }
        else{
            torchPref.transform.position=PlayerControler.Instance.transform.position+new Vector3(0.72f,0.67f,0);
        }
    }
    public void UpNumberTorch(){
        numberTorch+=1;
        textNumberTorch.text="x"+numberTorch.ToString();
    }


}
