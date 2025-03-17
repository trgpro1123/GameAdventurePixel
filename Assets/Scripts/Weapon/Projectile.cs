using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speedProjectile=10f;
    [SerializeField] GameObject hitPrefab;
    [SerializeField] private bool isProjectileEnemy;
    [SerializeField] private float projectileRange;
    

    private Vector3 startPosition;
 
    private void Start() {
        startPosition=transform.position;
    }
    private void Update() {
        MoveProjectile();
        DetectFireDistance();
    }

    private void MoveProjectile(){
        transform.Translate(Vector3.right*Time.deltaTime*speedProjectile);
    }

    private void DetectFireDistance(){
        if(Vector3.Distance(transform.position,startPosition)>projectileRange){
            Destroy(gameObject);
        }
    }

    public void UpdateProjectTile(float projectileRange){
        this.projectileRange=projectileRange;
    }
    public void UpdateSpeedProjectTile(float speedProjectile){
        this.speedProjectile=speedProjectile;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        HealthEnemy healthEnemy=other.gameObject.GetComponent<HealthEnemy>();
        Indestructible indestructible=other.gameObject.GetComponent<Indestructible>();
        PlayerHealth playerHealth=other.gameObject.GetComponent<PlayerHealth>();
        HealthBoss healthBoss=other.gameObject.GetComponent<HealthBoss>();

        if (!other.isTrigger && (healthEnemy || indestructible || playerHealth||healthBoss)) {
            if((playerHealth&&isProjectileEnemy)||(healthEnemy&&!isProjectileEnemy)||(healthBoss&&!isProjectileEnemy)){
                if(isProjectileEnemy) PlayerHealth.Instance.Freeze();
                playerHealth?.TakeDamage(1,transform);
                
                Instantiate(hitPrefab,transform.position,transform.rotation);
                Destroy(gameObject);
            }
             else if (!other.isTrigger && indestructible) {
                Instantiate(hitPrefab, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
    }


    
}
