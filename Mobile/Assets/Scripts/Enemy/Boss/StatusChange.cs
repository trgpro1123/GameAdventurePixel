using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusChange : MonoBehaviour
{

    private UbhShotCtrl ubhShotCtrl;

    private void OnDestroy() {
        UbhObjectPool.instance?.ReleaseAllBullet();
    }
    private void Awake() {
        ubhShotCtrl=GetComponent<UbhShotCtrl>();
    }
    [SerializeField] private UbhShotCtrl.ShotInfo[] form1ShotInfo;
    [SerializeField] private UbhShotCtrl.ShotInfo[] form2ShotInfo;
    public void AddShotForm2(){
        StopShotRoutine();
        ubhShotCtrl.m_shotList.Clear();
        foreach(UbhShotCtrl.ShotInfo shot in form2ShotInfo){
            ubhShotCtrl.m_shotList.Add(shot);
        }
        StartShotRoutine();
    }
    public void AddShotForm1(){
        StopShotRoutine();
        ubhShotCtrl.m_shotList.Clear();
        foreach(UbhShotCtrl.ShotInfo shot in form1ShotInfo){
            ubhShotCtrl.m_shotList.Add(shot);
        }
        StartShotRoutine();
    }
    public void StopShotRoutine(){
        ubhShotCtrl.StopShotRoutineAndPlayingShot();
    }
    public void StartShotRoutine(){
        ubhShotCtrl.StartShotRoutine(1);
    }

}
