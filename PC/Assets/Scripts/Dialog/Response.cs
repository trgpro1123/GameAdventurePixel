using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class Response
{
    [SerializeField] private string responeseText;
    [SerializeField] private Dialogue dialogue;
    [SerializeField] private GameObject button;


    public string ResponeseText=>responeseText;
    public Dialogue Dialogues=>dialogue;
    public GameObject Buttons=>button;
}
