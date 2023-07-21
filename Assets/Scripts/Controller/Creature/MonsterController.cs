using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : CreatureController
{
    Rigidbody2D rigid;
    TreeController _target;
    public Define.MonsterType type;
    void Start()
    {
        // 서버에서 정보 가져오는 동안 생기는 딜레이
        //if (Managers.Game.LoadCompleted == true)
        //    Stat = new Stat(Managers.Data.MonsterData[8], Managers.Data.MonsterData[9], Managers.Data.MonsterData[10], Managers.Data.MonsterData[11], Managers.Data.MonsterData[12]);
        //else
            Stat = new Stat(2, 10, 1, 10, 10);

        rigid = GetComponent<Rigidbody2D>();
        _target = GameObject.Find("Tree").GetComponent<TreeController>();
        // 디폴트 State Moving으로 바꿈
        State = Define.CreatureState.Moving;
        Managers.Game.monsters.Add(this);
    }
    void InitStat()
    {

    }
    void Update()
    {
        switch (State)
        {
            case Define.CreatureState.Moving:
                FollowTree();
                break;
            case Define.CreatureState.Skill:
                UpdateSkill();
                break;
            case Define.CreatureState.Dead:
                UpdateDead();
                break;
        }
    }
    void UpdateDead()
    {

    }
    void UpdateSkill()
    {

    }
    void FollowTree()
    {
        float speed;
        float dir = _target.transform.position.x - transform.position.x;
        if (dir > 0)
        {
            speed = 1 * Stat.MoveSpeed;
            State = Define.CreatureState.Moving;
        }
        else
        {
            speed = (-1) * Stat.MoveSpeed;
            State = Define.CreatureState.Moving;
        }
        rigid.velocity = new Vector2(speed, rigid.velocity.y);
    }
    public override void OnDead()
    {
        Managers.Game.monsters.Remove(this);
        base.OnDead();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Tree")
        {
            State = Define.CreatureState.Skill;
            _target.OnDamaged(Stat.Attack);
        }
    }
}
