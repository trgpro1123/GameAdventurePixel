using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BulletGun : Singleton<BulletGun>
{
    [SerializeField] private Button reloadButton;
    [SerializeField] private TMP_Text textProjectile;
    [SerializeField] private Image timer;
    [SerializeField] private float timeReloadDuration=4;
    [SerializeField] private int magazine=50;
    public int currentNumberProjectile;
    public bool isReload;


    private void Start() {
        SetTextProjectile();
        timer.fillAmount=0;
        ActiveProjectileUI(false);
        reloadButton.onClick.AddListener(Reload);
    }
    public void SetTextProjectile(){
        textProjectile.text=currentNumberProjectile.ToString();
        if(currentNumberProjectile==0){
            textProjectile.color=Color.red;
        }
        else textProjectile.color=Color.white;
    }
    public void Reload(){
        if(!isReload&&currentNumberProjectile<magazine){
            StartCoroutine(ReloadBullet());
        }
    }

     public IEnumerator ReloadBullet(){
        isReload=true;
        timer.fillAmount=timeReloadDuration;
        float timePass=timeReloadDuration;
        while(timer.fillAmount>0){
            timePass-=Time.deltaTime;
            timer.fillAmount=timePass/timeReloadDuration;
            yield return null;
        }
        BulletGun.Instance.currentNumberProjectile=magazine;
        BulletGun.Instance.SetTextProjectile();
        isReload=false;
        
    }
    public void StopRelaodBullet(){
            
        try{
            timer.fillAmount=0;
            isReload=false;
            StopAllCoroutines();}
        catch (System.Exception){} 
            
    }
    public void ActiveReloadButton(bool value){
        reloadButton.gameObject.SetActive(value);
    }
    public void ActiveProjectileUI(bool value){
        textProjectile.gameObject.SetActive(value);
        timer.gameObject.SetActive(value);
    }
    public bool GetAtivity(){
        return textProjectile.gameObject.activeSelf;
    }

}
