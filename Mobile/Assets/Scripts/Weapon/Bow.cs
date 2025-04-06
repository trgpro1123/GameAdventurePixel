using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour,IWeapon
{

    [SerializeField] private WeaponInfo weaponInfo;
    [SerializeField] private GameObject bowPrefab;
    [SerializeField] private Sprite bowUpdate;
    [SerializeField] private Transform arrowSpawnPoint;

    private Animator myAnimator;
    private AudioSource audioSource;
    private SpriteRenderer spriteRenderer;
    private Vector2 lastAngle;

    readonly int FIRE_HASH=Animator.StringToHash("Fire");
    private void Awake() {
        myAnimator=GetComponent<Animator>();
        audioSource=GetComponent<AudioSource>();
        spriteRenderer=GetComponent<SpriteRenderer>();

    }
    private void Start() {
        weaponInfo.isUpdate=false;
        if(EventStory.Instance.updateBow){
            spriteRenderer.sprite=bowUpdate;
            weaponInfo.isUpdate=true;
        }
    }
    void Update()
    {
        if(SettingMenu.Instance.GetIsOpenSetting()) return;
        FaceMouse();
    }
    public void Attack(){
        audioSource.Play();
        myAnimator.SetTrigger(FIRE_HASH);
        GameObject newArrow= Instantiate(bowPrefab,arrowSpawnPoint.position,ActiveSword.Instance.transform.rotation);
        newArrow.GetComponent<Projectile>().UpdateProjectTile(weaponInfo.weaponRange);
    }
    public WeaponInfo GetWeaponInfo(){
        return weaponInfo;
    }
    
    // private void FaceMouse(){
    //     Vector3 mousePosition=Input.mousePosition;
    //     mousePosition=Camera.main.ScreenToWorldPoint(mousePosition);
    //     Transform vector2ActiveSword=ActiveSword.Instance.transform;
    //     Vector2 direction=vector2ActiveSword.position-mousePosition;
    //     vector2ActiveSword.transform.right=-direction;

    // }
    private void FaceMouse()
    {
        // // Get direction from joystick instead of mouse
        // Vector2 attackDirection = UI.Instance.AttackJoystick.Direction;
        
        // // If no joystick input, keep current rotation
        // if (attackDirection.magnitude < 0.1f)
        //     return;
        
        // Transform vector2ActiveSword = ActiveSword.Instance.transform;
        
        // // Convert joystick direction to world space direction
        // Vector3 targetPosition = vector2ActiveSword.position + new Vector3(attackDirection.x, attackDirection.y, 0);
        // Vector2 direction = vector2ActiveSword.position - (Vector3)targetPosition;
        Transform vector2ActiveSword = ActiveSword.Instance.transform;
        Vector2 direction = UI.Instance.SetDirectionAttackJoystick(vector2ActiveSword);
        if(direction!=Vector2.zero)
            lastAngle=direction;
        
        vector2ActiveSword.transform.right = -lastAngle;
    }
}
