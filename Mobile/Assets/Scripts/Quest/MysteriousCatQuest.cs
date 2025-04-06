using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MysteriousCatQuest : DialogueActivator
{
    [SerializeField] private Dialogue startDialogue;
    [SerializeField] private Dialogue endDialogue;
    protected override void OpenDialogue()
    {
        if(EventStory.Instance.finishCat){
            PlayerControler.Instance.dialogueManager.StartDialogue(endDialogue);
        }else{
            PlayerControler.Instance.dialogueManager.StartDialogue(startDialogue);
        }
        
    }
}
