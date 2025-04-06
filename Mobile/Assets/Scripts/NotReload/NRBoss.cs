using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NRBoss : MonoBehaviour
{
    private void Awake() {

        if(EventStory.Instance.finishBoss){
            Destroy(gameObject);
        }
    }
    
}
