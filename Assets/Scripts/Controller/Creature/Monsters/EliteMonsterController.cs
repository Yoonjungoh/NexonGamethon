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
    public override void OnDead()
    {
        Managers.UI.ShowPopupUI<UI_EndPopup>();
        base.OnDead();
    }
    void Update()
    {
        base.UpdateController();
    }
}
