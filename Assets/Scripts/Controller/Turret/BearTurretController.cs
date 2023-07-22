using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearTurretController : TurretController
{
    protected override void Init()
    {
        type = Define.TurretType.Bear;
        level = Managers.Game.turret_Lv[3];
        base.Init();
    }
    protected override void Fire(MonsterController monster)
    {
        base.Fire(monster);
        animator.Play("BEAR_ATTACK");
    }
    void Start()
    {
        Init();
    }

    void Update()
    {
        base.UpdateController();
    }
}
