using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEmenies : MonoBehaviour
{
   
    [SerializeField] HealthBoss healthBoss;
    [SerializeField] private int numberHeal=20;
   [SerializeField] private PointSpawn[] pointSpawns;
   [SerializeField] private float timeSkillHealing=20f;
   [SerializeField] private float timeToNextSpawn=10f;


   private float currentTimeSkillHealling;
   private float currentTimePrepareSpawn;


   public void Spawn(){
        foreach(PointSpawn pointSpawn in pointSpawns){
            GameObject enemy=Instantiate(pointSpawn.EnemySpawn,pointSpawn.transformSpawn);
            enemy.transform.parent=this.transform;
        }
        
        StartCoroutine(SkillHealling());
   }





   private void Healing(){
        foreach(Transform enemy in this.transform){
            Destroy(enemy.gameObject);
            healthBoss.HealBoss(numberHeal); 
        }
        StopAllCoroutines();
        if(healthBoss.GetCurrentHealth()<=0 ){return;}
        else if(healthBoss.GetCurrentHealth()<=healthBoss.GetHealthTransForm()){
            StartCoroutine(PrepareToSpawn());
        }
        
   }

    public void StartPrepareToSpawn(){

        StartCoroutine(PrepareToSpawn());
    }



   private IEnumerator SkillHealling(){
        currentTimeSkillHealling=timeSkillHealing;
        while(currentTimeSkillHealling>=0){
            currentTimeSkillHealling-=Time.deltaTime;
            yield return null;
        }
        Healing();

   }

    private IEnumerator PrepareToSpawn(){
        currentTimePrepareSpawn=timeToNextSpawn;
        while(currentTimePrepareSpawn>=0){
            currentTimePrepareSpawn-=Time.deltaTime;
            yield return null;
        }
        
        Spawn();
   }


}
