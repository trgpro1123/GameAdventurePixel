using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Rendering.Universal;

public class MiniGun : MonoBehaviour,IWeapon
{
    [SerializeField] private WeaponInfo weaponInfo;
    [SerializeField] private GameObject bowPrefab;
    [SerializeField] private Transform arrowSpawnPoint;
    [SerializeField] FlashLight flashLight;

    [SerializeField] private ShakeWeapon shakeWeapon;
    //private ShakeWeapon shakeWeapon;
    
    
    private BulletShellGenerator bulletShellGenerator;
    private Animator myAnimator;
    readonly int FIRE_HASH=Animator.StringToHash("Fire");
    private SpriteRenderer spriteRenderer;
    private GunSoundEffect gunSoundEffect;
    private void Awake() {
        myAnimator=GetComponent<Animator>();
        spriteRenderer=GetComponent<SpriteRenderer>();
        flashLight=GetComponent<FlashLight>();
        bulletShellGenerator=GetComponentInChildren<BulletShellGenerator>();
        gunSoundEffect=GetComponent<GunSoundEffect>();

    }
    private void Start() {
        BulletGun.Instance.ActiveProjectileUI(true);
        BulletGun.Instance.SetTextProjectile();
        ActiveSword.Instance.transform.rotation=Quaternion.Euler(0,0,0);
        
    }
    private void OnDestroy() {
        try{BulletGun.Instance.StopRelaodBullet();}
        catch (System.Exception) {} 
    }
    private void Update() {
        if(SettingMenu.Instance.GetIsOpenSetting()) return;
        if(Input.GetKeyDown(KeyCode.R)&&!BulletGun.Instance.isReload){
            if(BulletGun.Instance.currentNumberProjectile<50) StartCoroutine(BulletGun.Instance.ReloadBullet());
            
        } 
            
        FaceMouse();
    }
    public void Attack(){
        if(BulletGun.Instance.currentNumberProjectile>0&&!BulletGun.Instance.isReload){
            gunSoundEffect.PlayFire();
            GetComponent<AudioSource>().Play();
            bulletShellGenerator.SpawnBulletShell();
            BulletGun.Instance.currentNumberProjectile-=1;
            BulletGun.Instance.SetTextProjectile();
            myAnimator.SetTrigger(FIRE_HASH);
            GameObject newArrow= Instantiate(bowPrefab,arrowSpawnPoint.position,transform.rotation);
            newArrow.GetComponent<Projectile>().UpdateProjectTile(weaponInfo.weaponRange);
            shakeWeapon.Shake();
            flashLight.Muzzle();
        }else{
            gunSoundEffect.PlayDryFire();
        }
        
    }
    public WeaponInfo GetWeaponInfo(){
        return weaponInfo;
    }
    private void FaceMouse(){
        Vector3 mousePosition=Input.mousePosition;
        mousePosition=Camera.main.ScreenToWorldPoint(mousePosition);
        Vector3 positionWorld=Camera.main.WorldToScreenPoint(PlayerControler.Instance.transform.position);
        Vector3 positionMose=Input.mousePosition;
        if(positionMose.x<positionWorld.x){
           spriteRenderer.flipY=true;
        }
        else{
            spriteRenderer.flipY=false;
        }
        Vector2 direction=transform.position-mousePosition;
        transform.right=-direction;


    }
   
    
    
}
