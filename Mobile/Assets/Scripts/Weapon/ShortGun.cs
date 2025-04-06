using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortGun : MonoBehaviour,IWeapon
{
    [SerializeField] private WeaponInfo weaponInfo;
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] FlashLight flashLight;

    private SpriteRenderer spriteRenderer;
    private ShortGunShooter shortGunShooter;
    private Animator myAnimator;
    readonly int FIRE_HASH=Animator.StringToHash("Fire");
    private void Awake() {
        myAnimator=GetComponent<Animator>();
        shortGunShooter=GetComponent<ShortGunShooter>();
        spriteRenderer=GetComponent<SpriteRenderer>();
        flashLight=GetComponent<FlashLight>();

    }
    void Update()
    {
        if(SettingMenu.Instance.GetIsOpenSetting()) return;
        FaceMouse();
    }
    public void Attack(){
        StopAllCoroutines();
        myAnimator.SetTrigger(FIRE_HASH);
        shortGunShooter.Attack();
        flashLight.Muzzle();
    }
    public WeaponInfo GetWeaponInfo(){
        return weaponInfo;
    }
    
    // private void FaceMouse(){
    //     Vector3 mousePosition=Input.mousePosition;
    //     Transform vector2ActiveSword=ActiveSword.Instance.transform;

    //     mousePosition=Camera.main.ScreenToWorldPoint(mousePosition);
    //     Vector2 direction=vector2ActiveSword.position-mousePosition;
    //     vector2ActiveSword.transform.right=-direction;

    //     Vector3 positionWorld=Camera.main.WorldToScreenPoint(PlayerControler.Instance.transform.position);
    //     Vector3 positionMose=Input.mousePosition;

    //     if(positionMose.x<positionWorld.x){
    //        spriteRenderer.flipY=true;
    //     }
    //     else{
    //         spriteRenderer.flipY=false;
    //     }
        

    // }
    private void FaceMouse(){
    // Lấy hướng từ joystick tấn công
    Vector2 joystickDirection = UI.Instance.AttackJoystick.Direction;
    
    // Nếu joystick không được di chuyển (magnitude gần 0), giữ nguyên góc hiện tại
    if (joystickDirection.magnitude < 0.1f)
        return;
    
    Transform vector2ActiveSword = ActiveSword.Instance.transform;
    
    // Sử dụng hướng joystick để tính toán góc quay
    vector2ActiveSword.transform.right = new Vector2(joystickDirection.x, joystickDirection.y);

    // Kiểm tra hướng ngang của joystick để quyết định lật sprite
    if (joystickDirection.x < 0){
        spriteRenderer.flipY = true;
    }
    else {
        spriteRenderer.flipY = false;
    }
}
     
}
