using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResponseHandler : MonoBehaviour
{
    [SerializeField] private Transform BoxButton;
    

    private DialogueManager dialogueManager;
    private List<GameObject> tempResponseButtons = new List<GameObject>();

    private void Start() {
        dialogueManager=GetComponent<DialogueManager>();
    }

    public void ShowResponse(Response[] response){
        
        for(int i=0;i<response.Length;i++){
            Response x=response[i];
            GameObject responseButton= Instantiate(response[i].Buttons,BoxButton);
            responseButton.gameObject.SetActive(true);
            tempResponseButtons.Add(responseButton);
        }
        BoxButton.gameObject.SetActive(true);
    }

  


    public void OnPickedResponse(Response response){
        this.gameObject.SetActive(false);
        if(tempResponseButtons.Count>0){
            foreach(GameObject button in tempResponseButtons){
                Destroy(button);
            }
            tempResponseButtons.Clear();
        }
        if(response.Dialogues){
            dialogueManager.StartDialogue(response.Dialogues);
        }else{
            dialogueManager.CloseDialogue();
        }
    }


}
