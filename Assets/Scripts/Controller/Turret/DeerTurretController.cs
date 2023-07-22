using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeerTurretController : TurretController
{
    protected override void Init()
    {
        type = Define.TurretType.Deer;
        level = Managers.Game.DeerTurretLevel;
        base.Init();
    }
    protected override void Fire(MonsterController monster)
    {
        base.Fire(monster);
        animator.Play("DEER_ATTACK");
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
