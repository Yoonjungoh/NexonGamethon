using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombMonsterController : MonsterController
{
    protected override void Init()
    {
        type = Define.MonsterType.Bomb;
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
