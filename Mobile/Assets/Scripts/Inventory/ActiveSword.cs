using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ActiveSword : Singleton<ActiveSword>
{
    public MonoBehaviour CurrentActiveWeapon {get;private set;}

    private PlayerControls playerControls;
    private bool attackButtonDown;
    public bool isAttack=false;
    private float timeBetweenAttack;
    public float attackJoystickThreshold = 0f;
    public Transform pointSpawn;



    protected override void Awake() {
        base.Awake();
        playerControls=new PlayerControls();   
    }
    private void OnEnable() {
        playerControls.Enable();
    }



    private void Start() {
        AttackCoolDown();
    }

    private void Update() {
        // Attack();
        Vector2 attackDirection = UI.Instance.AttackJoystick.Direction;
        // Start attacking when joystick exceeds threshold
        if (attackDirection.magnitude > attackJoystickThreshold && !isAttack)
        {
            Attack();
            StartAttacking();
            // isAttack = true;
        }
        else if (attackDirection.magnitude < attackJoystickThreshold && isAttack)
        {
            StopAttacking();
            // isAttack = false;
        }
    }

    public void NewWeapon(MonoBehaviour newWeapon){
        CurrentActiveWeapon=newWeapon;
        StartCoroutine(TimeChangeWeponesDownRoutine());
        timeBetweenAttack=(CurrentActiveWeapon as IWeapon).GetWeaponInfo().weaponCooldown;
    }
    public void WeaponNull(){
        CurrentActiveWeapon=null;
    }
    void StartAttacking(){
        attackButtonDown=true;
    }
    void StopAttacking(){
        attackButtonDown=false;
    }
 
    public void AttackCoolDown(){
        isAttack=true;
        StopAllCoroutines();
        StartCoroutine(TimeBetweenAttackDownRoutine());
    }

    private IEnumerator TimeBetweenAttackDownRoutine(){
        yield return new WaitForSeconds(timeBetweenAttack);
        isAttack=false;
    }
    private IEnumerator TimeChangeWeponesDownRoutine(){
        yield return new WaitForSeconds(1f);
        isAttack=false;
    }
    private void Attack(){
        if(SettingMenu.Instance.GetIsOpenSetting()) return;
        if(attackButtonDown&&!isAttack && CurrentActiveWeapon){
            
            AttackCoolDown();
            (CurrentActiveWeapon as IWeapon).Attack();
        }

    }



    
}
