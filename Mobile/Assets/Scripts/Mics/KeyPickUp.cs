using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickUp : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.GetComponent<PlayerControler>()){
            KeyUI.Instance.HasKey(true);
            Destroy(gameObject);
        }
    }
}
