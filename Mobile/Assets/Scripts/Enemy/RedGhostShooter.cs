using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedGhostShooter : MonoBehaviour,IEnemy
{
    
    private UbhHomingShot ubhHomingShot;
    private void Awake() {
        ubhHomingShot=GetComponentInChildren<UbhHomingShot>();
    }
    
    public void Attack()
    {
        ubhHomingShot.Shot();
    }
}
