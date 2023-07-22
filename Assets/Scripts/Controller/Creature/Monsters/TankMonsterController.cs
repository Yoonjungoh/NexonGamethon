using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMonsterController : MonsterController
{
    protected override void Init()
    {
        type = Define.MonsterType.Tank;
        base.Init();
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
