using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToUse : ButtonBase
{

    [SerializeField] Dialogue dialogue;
    protected override void OnClick()
    {
        AudioSource.PlayClipAtPoint(audioSource.clip,PlayerControler.Instance.transform.position);
        foreach(Response response in dialogue.responses){
            if(response.ResponeseText=="Đuốc là gì?") {
                GameObject.Find("Dialog").GetComponent<ResponseHandler>().OnPickedResponse(response);
            }
        }
    }
}
