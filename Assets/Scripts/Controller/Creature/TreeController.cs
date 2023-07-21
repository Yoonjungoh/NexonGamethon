using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeController : CreatureController
{
    UI_Turret turretUI;
    void Start()
    {
        //Stat = new Stat(Managers.Data.TreeData[5], Managers.Data.TreeData[6], Managers.Data.TreeData[7], Managers.Data.TreeData[8], Managers.Data.TreeData[9]);
        Stat = new Stat(500, 500, 500, 500, 500);
        // 디폴트 State Idle로 바꿈
        State = Define.CreatureState.Idle;

    }
    public void InitUI()
    {
        turretUI = Managers.UI.ShowSceneUI<UI_Turret>();
    }
    public override float OnDamaged(float damage)
    {
        base.OnDamaged(damage);
        Debug.Log("나무 체력: " + Stat.Hp);
        return damage;
    }
    public override void OnDead()
    {
        Managers.UI.ShowPopupUI<UI_DeadPopup>();
    }
}
