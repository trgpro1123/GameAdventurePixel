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
    
    private void FaceMouse(){
        Vector3 mousePosition=Input.mousePosition;
        mousePosition=Camera.main.ScreenToWorldPoint(mousePosition);
        Transform vector2ActiveSword=ActiveSword.Instance.transform;
        Vector2 direction=vector2ActiveSword.position-mousePosition;
        vector2ActiveSword.transform.right=-direction;

    }
}
