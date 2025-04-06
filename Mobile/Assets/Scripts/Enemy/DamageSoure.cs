using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSoure : MonoBehaviour
{

    private int damage;
    
    private MonoBehaviour currenActiveWeapon=>ActiveSword.Instance.CurrentActiveWeapon;
    private void Start() {
        if((currenActiveWeapon as IWeapon).GetWeaponInfo().isUpdate){
            damage=(currenActiveWeapon as IWeapon).GetWeaponInfo().weaponAfterUpdateDamege;
        }else{
            damage=(currenActiveWeapon as IWeapon).GetWeaponInfo().weaponDamege;
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
            HealthEnemy healthEnemy=other.gameObject.GetComponent<HealthEnemy>();
            HealthBoss healthBoss=other.gameObject.GetComponent<HealthBoss>();
            Archery archery=this.gameObject.GetComponent<Archery>();
            SwordUpdate swordUpdate=this.gameObject.GetComponent<SwordUpdate>();
            if(archery&&(currenActiveWeapon as IWeapon).GetWeaponInfo().isUpdate){
                healthEnemy?.TakeDamage(damage);
                healthBoss?.TakeDamage(damage);
                healthEnemy?.Freeze();
            }
            else if(swordUpdate&&(currenActiveWeapon as IWeapon).GetWeaponInfo().isUpdate){
                healthEnemy?.TakeDamage(damage);
                healthBoss?.TakeDamage(damage);
                healthEnemy?.NormalState();
            }
            else if(healthBoss||healthEnemy){
                healthEnemy?.TakeDamage(damage);
                healthBoss?.TakeDamage(damage);
            }
            
            
    }
}
