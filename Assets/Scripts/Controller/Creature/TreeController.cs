using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeController : CreatureController
{
    UI_Turret turretUI;
    public float maxHp;
    protected float perIncreaseHp = 100;
    public bool CanUltimateSkill = true;
    void Start()
    {
        Stat = new Stat(Managers.Data.TreeData[7], Managers.Data.TreeData[8], Managers.Data.TreeData[9], Managers.Data.TreeData[10], Managers.Data.TreeData[11]);
        Stat.Hp += perIncreaseHp * (Managers.Game.TreeHpLevel - 1);
        maxHp = Stat.Hp;
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
