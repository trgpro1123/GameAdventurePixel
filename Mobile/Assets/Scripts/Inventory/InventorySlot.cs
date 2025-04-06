using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour,IPointerDownHandler
{
    [SerializeField] private int slotIndex;
    [SerializeField] private WeaponInfo weaponInfo;

    public bool isNull=>weaponInfo==null;
    public WeaponInfo GetWeaponInfo(){
        return weaponInfo;
    }


    public void SetWeaponInfo(WeaponInfo weaponInfo){
        this.weaponInfo=weaponInfo;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        ActiveInventory.Instance.ToggleAciveHighlight(slotIndex);
    }
    
}
