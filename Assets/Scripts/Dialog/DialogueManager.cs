using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : Singleton<DialogueManager>
{
    
    [SerializeField] public TMP_Text nameNPC;
    [SerializeField] private TMP_Text conversation;

    private ResponseHandler responseHandler;

    public bool IsOpen { get; private set; }



    private void Start() {
        responseHandler=GetComponent<ResponseHandler>();
        CloseDialogue();

    }
    
    public void StartDialogue(Dialogue dialogue){

        if(dialogue.dialogues==null) CloseDialogue();
        IsOpen = true;
        this.gameObject.SetActive(true);
        StartCoroutine(StepThroughDialogue(dialogue));
    }

    private IEnumerator StepThroughDialogue(Dialogue dialogue){

        for(int i=0;i<dialogue.dialogues.Length;i++){
            yield return StartCoroutine(TypingSentence(dialogue.dialogues[i]));
            if(dialogue.dialogues.Length-1==i&&dialogue.hasResponses) break;
            yield return new WaitUntil(()=>Input.GetKeyDown(KeyCode.F));
        }
        if(dialogue.hasResponses){
            responseHandler.ShowResponse(dialogue.responses);
        }
        else{
            CloseDialogue();
        } 
            
            
    }

    private IEnumerator TypingSentence(string sentence){
        conversation.text=string.Empty;
        foreach(char letter in sentence.ToCharArray()){
            conversation.text+=letter;
            yield return null;
        }
    }

    public void CloseDialogue(){

        IsOpen = false;
        nameNPC.text=string.Empty;
        conversation.text=string.Empty;
        this.gameObject.SetActive(false);
    }
    

}
