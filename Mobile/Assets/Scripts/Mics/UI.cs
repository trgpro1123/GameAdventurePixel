using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : Singleton<UI>
{
    public Joystick MoveJoystick;
    public Joystick AttackJoystick;
    public Button dashButton;
    public Button optionButton;
    public Button interactButton;

    public bool triggerDialog;
    public GameObject uICanDisable;
    public PlayerControler playerControler;
    private void Start() {
        triggerDialog=false;
        playerControler=PlayerControler.Instance;
        dashButton.onClick.AddListener(()=>playerControler.Dash());
        optionButton.onClick.AddListener(()=>SettingMenu.Instance.StartSettingMenu());
        interactButton.onClick.AddListener(()=>playerControler.PlayerInteract());
        interactButton.gameObject.SetActive(false);
    }

    public Vector2 SetDirectionAttackJoystick(Transform tranformDirection)
    {
        Vector2 attackDirection = AttackJoystick.Direction;
        
        // If no joystick input, keep current rotation
        if (attackDirection.magnitude < 0.1f)
            return Vector2.zero;
        
        // Transform vector2ActiveSword = ActiveSword.Instance.transform;
        
        // Convert joystick direction to world space direction
        Vector3 targetPosition = tranformDirection.position + new Vector3(attackDirection.x, attackDirection.y, 0);
        return tranformDirection.position - (Vector3)targetPosition;
    }

}
