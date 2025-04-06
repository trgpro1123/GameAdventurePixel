using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateWeapon : ButtonBase
{

    [SerializeField] Dialogue dialogue;
    protected override void OnClick()
    {
        AudioSource.PlayClipAtPoint(audioSource.clip,PlayerControler.Instance.transform.position);
        foreach(Response response in dialogue.responses){
            if(response.ResponeseText=="Nâng cấp") {
                GameObject.Find("Dialog").GetComponent<ResponseHandler>().OnPickedResponse(response);
            }
        }
    }
}
