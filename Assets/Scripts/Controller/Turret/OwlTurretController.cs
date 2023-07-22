using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwlTurretController : TurretController
{
    protected override void Init()
    {
        type = Define.TurretType.Owl;
        level = Managers.Game.OwlTurretLevel;
        base.Init();
    }
    protected override void Fire(MonsterController monster)
    {
        base.Fire(monster);
        animator.Play("OWL_ATTACK");
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
