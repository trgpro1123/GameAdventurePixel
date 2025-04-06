using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillageMasterQuest : DialogueActivator
{

    [SerializeField] private Dialogue startDialogue;
    [SerializeField] private Dialogue finishStartVillageMasterQuest;
    [SerializeField] private Dialogue endDialogue;

    protected override void OpenDialogue()
    {
        if(EventStory.Instance.finishBoss){
            PlayerControler.Instance.dialogueManager.StartDialogue(endDialogue);
        }
        else if(EventStory.Instance.finishStartVillageMasterQuest){
            PlayerControler.Instance.dialogueManager.StartDialogue(finishStartVillageMasterQuest);
        }
        else{
            PlayerControler.Instance.dialogueManager.StartDialogue(startDialogue);
            EventStory.Instance.finishStartVillageMasterQuest=true;
            GetComponentInParent<BoxCollider2D>().enabled=false;
        }
        
    }
}
