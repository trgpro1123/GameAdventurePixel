using System;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class Shooter : MonoBehaviour,IEnemy
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float speedBullet;
    [SerializeField] private int burstCount;
    [SerializeField] private int projecttilesPerBurst;
    [SerializeField] [Range(0,359)]  private float angleSpread;
    [SerializeField] private float timeBetweenBurst;
    [SerializeField] private float resetTime;
    [SerializeField] private float startingDistance=0.2f;
    [SerializeField] private bool stagger;
    [SerializeField] private bool oscillate;



    private bool isShooting=false;





    private void OnValidate() {
        if (oscillate) { stagger = true; }
        if (!oscillate) { stagger = false; }
        if (projecttilesPerBurst < 1) { projecttilesPerBurst = 1; }
        if (burstCount < 1) { burstCount = 1; }
        if (timeBetweenBurst < 0.1f) { timeBetweenBurst = 0.1f; }
        if (resetTime < 0.1f) { resetTime = 0.1f; }
        if (startingDistance < 0.1f) { startingDistance = 0.1f; }
        if (angleSpread == 0) { projecttilesPerBurst = 1; }
        if (speedBullet <= 0) { speedBullet = 0.1f; }
    }





    public void Attack(){
        if(!isShooting){

            StartCoroutine(ShootRoutine());
        }
    }
    private void OnDisable() {
        StopAllCoroutines();
        isShooting=false;
    }


    private IEnumerator ShootRoutine()
    {
        isShooting=true;
        float timeBetweenProjectile=0f;
        float startAngle,currentAngle,angleStep,endAngle;
        TargetConeOfInfluence(out startAngle,out endAngle,out currentAngle,out angleStep);
        if(stagger) {timeBetweenProjectile=timeBetweenBurst/projecttilesPerBurst;}
        
        for (int i = 0; i < burstCount; i++)
        {
            if(!oscillate){TargetConeOfInfluence(out startAngle,out endAngle,out currentAngle,out angleStep);}

            if(oscillate&& i%2!=1){
                TargetConeOfInfluence(out startAngle,out endAngle,out currentAngle,out angleStep);
            }else if(oscillate){
                currentAngle=endAngle;
                endAngle=startAngle;
                startAngle=currentAngle;
                angleStep*=-1;
            }

            for (int j = 0; j < projecttilesPerBurst; j++)
            {
                Vector2 pos= FindBulletSpawnPoint(currentAngle);
                GameObject newBullet = Instantiate(bulletPrefab, pos, Quaternion.identity);
                //newBullet.transform.right = newBullet.transform.position-transform.position;
                 newBullet.transform.rotation = Quaternion.Euler(0, 0, currentAngle);
                if(newBullet.TryGetComponent(out Projectile projectile)){
                    projectile.UpdateSpeedProjectTile(speedBullet);
                }

                currentAngle+=angleStep;
                if(stagger){yield return new WaitForSeconds(timeBetweenProjectile);}
            }
            currentAngle=startAngle;
            if(!stagger) yield return new WaitForSeconds(timeBetweenBurst);
            
            
        }
        yield return new WaitForSeconds(resetTime);
        isShooting=false;
    }

    private void TargetConeOfInfluence(out float startAngle,out float endAngle,out float currentAngle,out float angleStep)
    {   
        
        Vector2 targetDirection = PlayerControler.Instance.transform.position - transform.position;
        float targetAngle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
        startAngle = targetAngle;
        endAngle = targetAngle;
        currentAngle = targetAngle;
        float haftAngleSpread = 0f;
        angleStep = 0f;
        if (angleSpread != 0)
        {
            angleStep = angleSpread / (projecttilesPerBurst - 1);
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
