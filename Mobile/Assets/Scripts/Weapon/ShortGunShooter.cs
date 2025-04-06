using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortGunShooter : MonoBehaviour
{


    [SerializeField] private WeaponInfo weaponInfo;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private int numberProjecttiles;
    [SerializeField] [Range(0,359)]  private float angleSpread;
    [SerializeField] private float startingDistance=0.2f;




    private bool isShooting=false;
    private GunSoundEffect gunSoundEffect;
    private void Start() {
        gunSoundEffect=GetComponent<GunSoundEffect>();
    }

    public void Attack(){
        if(!isShooting){
            gunSoundEffect.PlayFire();
            StartCoroutine(ShootRoutine());
        }
        else gunSoundEffect?.PlayDryFire();
    }

    private IEnumerator ShootRoutine()
    {
        isShooting=true;
        float startAngle,currentAngle,angleStep,endAngle;
        TargetConeOfInfluence(out startAngle,out endAngle,out currentAngle,out angleStep);
            for (int j = 0; j < numberProjecttiles; j++)
            {
                Vector2 pos= FindBulletSpawnPoint(currentAngle);
                GameObject newBullet = Instantiate(bulletPrefab, pos, Quaternion.identity);
                newBullet.transform.rotation = Quaternion.Euler(0, 0, currentAngle);
                currentAngle+=angleStep;
            }
            currentAngle=startAngle; 
        yield return new WaitForSeconds(weaponInfo.weaponCooldown);
        isShooting=false;
    }

    private void TargetConeOfInfluence(out float startAngle,out float endAngle,out float currentAngle,out float angleStep)
    {
        // Lấy hướng từ joystick tấn công
        Vector2 joystickDirection = UI.Instance.AttackJoystick.Direction;
        
        // Nếu joystick không được di chuyển (magnitude gần 0), sử dụng hướng mặc định
        if (joystickDirection.magnitude < 0.1f)
        {
            // Sử dụng hướng nhìn của người chơi nếu joystick không được sử dụng
            if (PlayerControler.Instance.facingLeft)
                joystickDirection = new Vector2(-1, 0);
            else
                joystickDirection = new Vector2(1, 0);
        }
        
        // Tính góc dựa trên hướng joystick
        float targetAngle = Mathf.Atan2(joystickDirection.y, joystickDirection.x) * Mathf.Rad2Deg;
        

        // Vector3 mousePosition=Input.mousePosition;
        // mousePosition=Camera.main.ScreenToWorldPoint(mousePosition);
        // Vector2 targetDirection = mousePosition - transform.position;
        // float targetAngle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
        startAngle = targetAngle;
        endAngle = targetAngle;
        currentAngle = targetAngle;
        float haftAngleSpread = 0f;
        angleStep = 0f;
        if (angleSpread != 0)
        {
            angleStep = angleSpread / (numberProjecttiles - 1);
            haftAngleSpread = angleSpread / 2;
            startAngle = targetAngle - haftAngleSpread;
            endAngle = targetAngle + haftAngleSpread;
            currentAngle = startAngle;

        }
    }


    private Vector2 FindBulletSpawnPoint(float currentAngle){
        float x=transform.position.x+startingDistance*Mathf.Cos(currentAngle*Mathf.Deg2Rad);
        float y=transform.position.y+startingDistance*Mathf.Sin(currentAngle*Mathf.Deg2Rad);
        
        Vector2 pos=new Vector2(x,y);
        return pos;
    }

}
