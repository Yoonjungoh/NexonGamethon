using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliteMonsterController : MonsterController
{
    protected override void Init()
    {
        type = Define.MonsterType.Elite;
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
