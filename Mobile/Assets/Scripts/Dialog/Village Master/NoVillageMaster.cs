using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoVillageMaster : ButtonBase
{
    
    [SerializeField] Dialogue dialogue;
    protected override void OnClick()
    {
        SettingMenu.Instance.BackToMainMenu();
    }

}
