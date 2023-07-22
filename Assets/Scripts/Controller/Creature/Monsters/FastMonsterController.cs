using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastMonsterController : MonsterController
{
    protected override void Init()
    {
        type = Define.MonsterType.Fast;
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
