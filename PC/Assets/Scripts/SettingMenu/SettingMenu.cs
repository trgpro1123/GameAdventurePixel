using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingMenu : Singleton<SettingMenu>
{
    

    [SerializeField] private GameObject sureExit;
    private bool isOpenSetting=false;
    private Animator animator;
    readonly int IDLE_HASH=Animator.StringToHash("Idle");
    readonly int START_HASH=Animator.StringToHash("StartSetting");
    readonly int CLOSE_HASH=Animator.StringToHash("CloseSetting");

    protected override void Awake() {
        base.Awake();
        animator=GetComponent<Animator>();

    }
    private void Start() {
        isOpenSetting=false;
        StartTimeScalse();
        DisableSureExit();
        animator.SetTrigger(IDLE_HASH);
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)&&!isOpenSetting){
            StartSettingMenu();
        }else if(Input.GetKeyDown(KeyCode.Escape)&&isOpenSetting){
            CloseSettingMenu();
            
        }
    }
    private void StartSettingMenu(){
        animator.SetTrigger(START_HASH);
        isOpenSetting=true;
    }
    public void CloseSettingMenu(){
        if(isOpenSetting){
            animator.SetTrigger(CLOSE_HASH);
            isOpenSetting=false;
            StartTimeScalse();
            DisableSureExit();
        }
    }
    public void StartTimeScalse(){
        Time.timeScale=1f;
    }
    public void StopTimeScalse(){
        Time.timeScale=0f;
    }
    public bool GetIsOpenSetting(){
        return isOpenSetting;
    }
    public void EnebleSureExit(){
        sureExit.SetActive(true);
    }
    public void DisableSureExit(){
        sureExit.SetActive(false);
    }
    public void BackToMainMenu(){
        
        Time.timeScale=1f;
        UIFade.Instance.FadeToBlack();
        Invoke("DeleteAllDonDestroyOnLoad",1f); 
    }
    private void DeleteAllDonDestroyOnLoad(){
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("DontDestroyOnLoad");
        foreach (GameObject gameObject in gameObjects)
        {
            Destroy(gameObject);
        }
        SceneManager.LoadScene(0);
    }
    
}
