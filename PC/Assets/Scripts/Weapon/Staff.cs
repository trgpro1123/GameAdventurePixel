using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staff : MonoBehaviour,IWeapon
{
    [SerializeField] private WeaponInfo weaponInfo;
    [SerializeField] private GameObject lazerPrefab;
    [SerializeField] private Transform pointSpawn;
    [SerializeField] private Material materialUpdate;
    [SerializeField] private SpriteRenderer gemSprite;

    private Animator myAnimator;
    private AudioSource audioSource;
    private SpriteRenderer spriteRenderer;

    readonly int ATTACK_HASH=Animator.StringToHash("Fire");

    private void Awake() {
        myAnimator=GetComponent<Animator>();
        audioSource=GetComponent<AudioSource>();
        spriteRenderer=GetComponentInChildren<SpriteRenderer>();
    }
    private void Start() {
        weaponInfo.isUpdate=false;
        if(EventStory.Instance.updateStaff){
            gemSprite.material=materialUpdate;
            weaponInfo.isUpdate=true;
        }
    }
    public void Attack(){
        myAnimator.SetTrigger(ATTACK_HASH);
        
    }

    public void SpwanStaffProjectileAnimEvent(){
        audioSource.Play();
        GameObject newLazer=Instantiate(lazerPrefab,pointSpawn.position,Quaternion.identity);
        newLazer.GetComponent<MagicLazer>().UpdateRangeLazer(weaponInfo.weaponRange);
    }
    public WeaponInfo GetWeaponInfo(){
        return weaponInfo;
    }
    private void Update() {
        if(SettingMenu.Instance.GetIsOpenSetting()) return;
        
        MouseFollowWithOffset();
    }

    void MouseFollowWithOffset(){
        Vector2 positionMose=Input.mousePosition;
        Vector3 positionWorld=Camera.main.WorldToScreenPoint(PlayerControler.Instance.transform.position);

        float angle=Mathf.Atan2(positionMose.y,positionMose.x)*Mathf.Rad2Deg;
        if(positionMose.x<positionWorld.x){
            ActiveSword.Instance.transform.rotation=Quaternion.Euler(0,-180,angle);

        }
        else{
            ActiveSword.Instance.transform.rotation=Quaternion.Euler(0,0,angle);

        }
    }
}
