using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(menuName ="Dialogue/ObjectDialogue")]
public class Dialogue : ScriptableObject
{
    [SerializeField] [TextArea] private string[] dialogue;
    [SerializeField] Response[] response;
    public bool hasResponses => (response != null && response.Length > 0);
    public string[] dialogues =>dialogue;
    public Response[] responses=>response;
}
