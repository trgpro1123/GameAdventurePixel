using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ShakeWeapon : MonoBehaviour
{
    [SerializeField] private GameObject weapon;
    [SerializeField] private float duaration,streght,ramdomness;
    [SerializeField] private int vibrato;
    [SerializeField] private bool snapping=false,fadeout=true;
    public void Shake(){
        StopShake();
        weapon.transform.DOShakePosition(duaration,streght,vibrato,ramdomness,snapping,fadeout);
    }
    private void StopShake(){
        weapon.transform.DOComplete();
    }
    

}
