using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveInventory : Singleton<ActiveInventory>
{
    private PlayerControls playerControls;
    public int activitiSlotIndexNum=-1;
    private PlayerControler playerControler;



    protected override void Awake() {
        base.Awake();
        playerControls=new PlayerControls();
    }

    private void Start()
    {
        playerControls.Inventory.KeyBoard.performed+=ctx=>ToggleActiveSlot((int)ctx.ReadValue<float>());
        playerControler=PlayerControler.Instance;
    }
    public void EquipStartWeapon(){
        ToggleAciveHighlight(0);
    }
    private void OnEnable() {
        playerControls.Enable();
    }
    private void OnDestroy() {
        playerControls.Disable();
    }
    private void ToggleActiveSlot(int valueNum){
        ToggleAciveHighlight(valueNum-1);
    }
    public void ToggleAciveHighlight(int indexNum){
        if(activitiSlotIndexNum==indexNum) return;
        activitiSlotIndexNum=indexNum;

        foreach(Transform inventorySlot in this.transform){
            inventorySlot.GetChild(0).gameObject.SetActive(false);
        }
        this.transform.GetChild(indexNum).GetChild(0).gameObject.SetActive(true);
        ChangeActiveWeapon();
    }

    public void ChangeActiveWeapon(){
        BulletGun.Instance.ActiveProjectileUI(false);
        BulletGun.Instance.ActiveReloadButton(false);
        if(ActiveSword.Instance.CurrentActiveWeapon!=null){
            Destroy(ActiveSword.Instance.CurrentActiveWeapon.gameObject);
        }

        Transform childTransform=transform.GetChild(activitiSlotIndexNum);
        InventorySlot inventorySlot=childTransform.GetComponentInChildren<InventorySlot>();
        WeaponInfo weaponInfo=inventorySlot.GetWeaponInfo();
        GameObject weaponSpawn=weaponInfo?.weaponPrefab;

        if(weaponInfo==null){
            ActiveSword.Instance.WeaponNull();
            return;
        }

        // Vector2 attackDirection = UI.Instance.AttackJoystick.Direction;
        // float angle=Mathf.Atan2(attackDirection.y, attackDirection.x) * Mathf.Rad2Deg;
        // if(weaponInfo.weaponType==WeaponType.Sword){
        ActiveSword.Instance.transform.rotation=Quaternion.Euler(0,0,0);
        GameObject newWeapon=Instantiate(weaponSpawn,GameObject.Find("PointSpawn").transform.position,Quaternion.identity,ActiveSword.Instance.transform);
            
        // }
        // ActiveSword.Instance.transform.rotation=Quaternion.Euler(0,0,0);

        // newWeapon.transform.parent=ActiveSword.Instance.transform;

        ActiveSword.Instance.NewWeapon(newWeapon.GetComponent<MonoBehaviour>());
        
    }
    
    

    
}
