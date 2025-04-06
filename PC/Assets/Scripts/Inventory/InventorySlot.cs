using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] private WeaponInfo weaponInfo;

    public bool isNull=>weaponInfo==null;
    public WeaponInfo GetWeaponInfo(){
        return weaponInfo;
    }
    public void SetWeaponInfo(WeaponInfo weaponInfo){
        this.weaponInfo=weaponInfo;
    }
    
}
