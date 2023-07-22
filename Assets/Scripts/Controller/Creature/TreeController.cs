using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeController : CreatureController
{
    UI_Turret turretUI;
    public float maxHp;
    void Start()
    {
        Stat = new Stat(Managers.Data.TreeData[7], Managers.Data.TreeData[8], Managers.Data.TreeData[9], Managers.Data.TreeData[10], Managers.Data.TreeData[11]);
        maxHp = Managers.Data.TreeData[7];
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
