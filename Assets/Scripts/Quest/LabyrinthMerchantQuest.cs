using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabyrinthMerchantQuest : DialogueActivator
{
    [SerializeField] private Dialogue startDialogue;

    protected override void OpenDialogue()
    {
        PlayerControler.Instance.dialogueManager.StartDialogue(startDialogue);
    }
}
