using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonMonsterController : MonsterController
{
    protected override void Init()
    {
        type = Define.MonsterType.Common;
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
