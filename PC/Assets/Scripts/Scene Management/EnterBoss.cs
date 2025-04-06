using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterBoss : MonoBehaviour
{
    private StatusChange statusChange;
    private void Start() {
        statusChange=GameObject.Find("Boss").GetComponentInChildren<StatusChange>();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.GetComponent<PlayerControler>()){
            if(!EventStory.Instance.finishBoss) statusChange?.StartShotRoutine();
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.GetComponent<PlayerControler>()){
             if(!EventStory.Instance.finishBoss) statusChange?.StopShotRoutine();
        }
    }
}
