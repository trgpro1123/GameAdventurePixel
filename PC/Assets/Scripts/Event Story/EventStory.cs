using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventStory : Singleton<EventStory>
{

    public bool hasKey=false;
    public bool finishBoss=false,finishStartVillageMasterQuest=false, finishCat=false,openTorch=false;
    public bool openShortgun=false;
    public bool updateSword=false,updateBow=false,updateStaff=false;
    
    protected override void Awake() {
        base.Awake();
    }
    private void Start() {
        TorchPlayer.Instance.gameObject.SetActive(false);
        KeyUI.Instance.HasKey(false);
    }



    public void OpenTorch(){
        openTorch=true;
        TorchPlayer.Instance.gameObject.SetActive(true);
    }
    
}
