using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YesVillageMaster : ButtonBase
{
    [SerializeField] Dialogue dialogue;
    protected override void OnClick()
    {
        foreach(Response response in dialogue.responses){
            if(response.ResponeseText=="Đồng ý") {
                AudioSource.PlayClipAtPoint(audioSource.clip,PlayerControler.Instance.transform.position);
                GameObject.Find("Dialog").GetComponent<ResponseHandler>().OnPickedResponse(response);
            }
        }
    }
}
