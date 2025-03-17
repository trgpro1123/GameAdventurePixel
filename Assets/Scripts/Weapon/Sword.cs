using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour,IWeapon
{

    [SerializeField] GameObject slashAttackPrefab;
    [SerializeField] float timeAttack;
    [SerializeField] private WeaponInfo weaponInfo;
    [SerializeField] private int damePlusAfterUpdate;

    private Transform weaponCollider;
    private Animator animator;
    private GameObject slashAnim;
    private Transform pointSpawnAttack;
    private AudioSource audioSource;
    private SpriteRenderer spriteRenderer;
    
    private void Awake() {
        
        animator=GetComponent<Animator>();
        pointSpawnAttack=GameObject.Find("PointSpawn").transform;
        audioSource=GetComponent<AudioSource>();
        spriteRenderer=GetComponent<SpriteRenderer>();
    }

    
    void Start()
    {
        weaponCollider=PlayerControler.Instance.GetWeaponCollider();
        weaponInfo.isUpdate=false;
        if(EventStory.Instance.updateSword){
            spriteRenderer.color=Color.red;
            weaponInfo.isUpdate=true;
        }else{
            spriteRenderer.color=Color.white;
        }



    }
    private void Update() {
        if(SettingMenu.Instance.GetIsOpenSetting()) return;
        MouseFollowWithOffset();
        
    }
    public WeaponInfo GetWeaponInfo(){
        return weaponInfo;
    }
    public void Attack(){
        
        audioSource.Play();
        animator.SetTrigger("Attack");
        weaponCollider.gameObject.SetActive(true);
        slashAnim=Instantiate(slashAttackPrefab,pointSpawnAttack.position,Quaternion.identity);
        slashAnim.transform.parent=this.transform.parent;
        StartCoroutine(AttackCDRoutine());

        

    }

    

    IEnumerator AttackCDRoutine(){
        yield return new WaitForSeconds(timeAttack);
        
    }
    private void ActtackDone(){
        weaponCollider.gameObject.SetActive(false);
    }   

    public void SwingUpFlipAnimation(){
        slashAnim.gameObject.transform.rotation=Quaternion.Euler(-180,0,0);
        if(PlayerControler.Instance.facingLeft){
            slashAnim.GetComponent<SpriteRenderer>().flipX=true;
        }
    }
    public void SwingDownFlipAnimation(){
        slashAnim.gameObject.transform.rotation=Quaternion.Euler(0,0,0);
        if(PlayerControler.Instance.facingLeft){
            slashAnim.GetComponent<SpriteRenderer>().flipX=true;
        }
    }



    void MouseFollowWithOffset(){
        Vector2 positionMose=Input.mousePosition;
        Vector3 positionWorld=Camera.main.WorldToScreenPoint(PlayerControler.Instance.transform.position);

        float angle=Mathf.Atan2(positionMose.y,positionMose.x)*Mathf.Rad2Deg;
        if(positionMose.x<positionWorld.x){
            ActiveSword.Instance.transform.rotation=Quaternion.Euler(0,-180,angle);
            weaponCollider.transform.rotation=Quaternion.Euler(0,-180,0);

        }
        else{
            ActiveSword.Instance.transform.rotation=Quaternion.Euler(0,0,angle);
            weaponCollider.transform.rotation=Quaternion.Euler(0,0,0);
        }
    }
}
