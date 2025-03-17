using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockNewWeapon : MonoBehaviour
{
    [SerializeField] private WeaponInfo weaponInfo;
    [SerializeField] private Sprite imageWeapon;
    [SerializeField] private Vector2 widthHeight;
    private Transform activeInventory;
    
    private void Start() {
        activeInventory=ActiveInventory.Instance.gameObject.transform;
    }

    public void UnlockWeapon(){
        foreach(Transform inventorySlot in activeInventory.transform){
            if(inventorySlot.gameObject.GetComponent<InventorySlot>().isNull) {
                SetUpWeapon(inventorySlot);
                return;
            }
        }
    }
    private void SetUpWeapon(Transform index){
        RectTransform rectTransform=index.GetChild(1).GetComponent<RectTransform>();
        Image image=index.GetChild(1).GetComponent<Image>();
        index.gameObject.GetComponent<InventorySlot>().SetWeaponInfo(weaponInfo);
        image.sprite=imageWeapon;
        image.color=new Color(255,255,255,255);
        rectTransform.sizeDelta=widthHeight;
        
    }
}
