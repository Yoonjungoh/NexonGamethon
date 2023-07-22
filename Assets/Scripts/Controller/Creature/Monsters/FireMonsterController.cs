using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMonsterController : MonsterController
{
    protected override void Init()
    {
        type = Define.MonsterType.Fire;
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
