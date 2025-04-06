using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class DialogueActivator : MonoBehaviour,IInteractable
{
    [SerializeField] private string nameNPC;
    [SerializeField] private GameObject arrowhead;
    private void Awake() {
        arrowhead.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerControler>() && other.TryGetComponent(out PlayerControler player))
        {
            UI.Instance.interactButton.gameObject.SetActive(true);
            player.Interactable = this;
            arrowhead.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerControler>() && other.TryGetComponent(out PlayerControler player))
        {
            if (player.Interactable is DialogueActivator dialogueActivator && dialogueActivator == this)
            {
                UI.Instance.interactButton.gameObject.SetActive(false);
                player.Interactable = null;
                arrowhead.SetActive(false);
            }
        }
    }
    public void Interact()
    {
        DialogueManager.Instance.nameNPC.text=this.nameNPC;
        OpenDialogue();
        
    }
    protected abstract void OpenDialogue();
    

}
