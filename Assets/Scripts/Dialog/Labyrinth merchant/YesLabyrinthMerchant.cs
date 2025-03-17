using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YesLabyrinthMerchant : ButtonBase
{
    [SerializeField] Dialogue dialogue;
    protected override void OnClick()
    {
        AudioSource.PlayClipAtPoint(audioSource.clip,PlayerControler.Instance.transform.position);
        
        foreach(Response response in dialogue.responses){
            if(response.ResponeseText=="Có") {
                GameObject.Find("Dialog").GetComponent<ResponseHandler>().OnPickedResponse(response);
            }
        }
    }
}
