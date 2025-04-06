using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OKMysteriousCat : ButtonBase
{
    [SerializeField] Dialogue dialogue;
    protected override void OnClick()
    {
        EventStory.Instance.finishCat=true;
        EventStory.Instance.openShortgun=true;
        EconomyManager.Instance.PlusCoin(10);
        audioSource.Play();
        foreach(Response response in dialogue.responses){
            if(response.ResponeseText=="OK!") {
                
                GameObject.Find("Dialog").GetComponent<ResponseHandler>().OnPickedResponse(response);
            }
        }
        
    }
}

