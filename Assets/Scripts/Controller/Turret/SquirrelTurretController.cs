using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquirrelTurretController : TurretController
{
    protected override void Init()
    {
        type = Define.TurretType.Squirrel;
        level = Managers.Game.SquirrelTurretLevel;
        base.Init();
    }
    protected override void Fire(MonsterController monster)
    {
        base.Fire(monster);
        animator.Play("SQUIRREL_ATTACK");
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
