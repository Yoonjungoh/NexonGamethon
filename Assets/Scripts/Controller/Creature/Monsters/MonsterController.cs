using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : CreatureController
{
    protected Rigidbody2D rigid;
    protected TreeController _target;
    public Define.MonsterType type;
    public Define.MoveDir moveDir;
    public float MovingDelay = 100f;
    protected virtual void Init()
    {
        Stat = GetComponent<Stat>();

        InitStat();

        rigid = GetComponent<Rigidbody2D>();
        _target = GameObject.Find("Tree").GetComponent<TreeController>();
        // 디폴트 State Moving으로 바꿈
        State = Define.CreatureState.Idle;
        // 방향 설정
        float dir = _target.transform.position.x - transform.position.x;
        if (dir > 0)
        {
            moveDir = Define.MoveDir.Right;
            transform.localScale = new Vector3(-1, 1, 0);
        }
        else
        {
            moveDir = Define.MoveDir.Left;
            transform.localScale = new Vector3(1, 1, 0);
        }
    }
    protected void InitStat()
    {
        switch (type)
        {
            case Define.MonsterType.Common:
                Stat.Hp = Managers.Data.MonsterData[8];
                Stat.Attack = Managers.Data.MonsterData[9];
                Stat.MoveSpeed = Managers.Data.MonsterData[10];
                Stat.AttackSpeed = Managers.Data.MonsterData[11];
                Stat.AttackRange = Managers.Data.MonsterData[12];
                break;
            case Define.MonsterType.Fire:
                Stat.Hp = Managers.Data.MonsterData[15];
                Stat.Attack = Managers.Data.MonsterData[16];
                Stat.MoveSpeed = Managers.Data.MonsterData[17];
                Stat.AttackSpeed = Managers.Data.MonsterData[18];
                Stat.AttackRange = Managers.Data.MonsterData[19];
                break;
            case Define.MonsterType.Tank:
                Stat.Hp = Managers.Data.MonsterData[22];
                Stat.Attack = Managers.Data.MonsterData[23];
                Stat.MoveSpeed = Managers.Data.MonsterData[24];
                Stat.AttackSpeed = Managers.Data.MonsterData[25];
                Stat.AttackRange = Managers.Data.MonsterData[26];
                break;
            case Define.MonsterType.Fast:
                Stat.Hp = Managers.Data.MonsterData[29];
                Stat.Attack = Managers.Data.MonsterData[30];
                Stat.MoveSpeed = Managers.Data.MonsterData[31];
                Stat.AttackSpeed = Managers.Data.MonsterData[32];
                Stat.AttackRange = Managers.Data.MonsterData[33];
                break;
            case Define.MonsterType.Bomb:
                Stat.Hp = Managers.Data.MonsterData[36];
                Stat.Attack = Managers.Data.MonsterData[37];
                Stat.MoveSpeed = Managers.Data.MonsterData[38];
                Stat.AttackSpeed = Managers.Data.MonsterData[39];
                Stat.AttackRange = Managers.Data.MonsterData[40];
                break;
        }

    }
    protected virtual void UpdateController()
    {
        switch (State)
        {
            case Define.CreatureState.Idle:
                UpdateIdle();
                break;
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
    protected virtual void UpdateDead()
    {

    }
    protected virtual void UpdateSkill()
    {

    }
    float timer = 0f;
    protected virtual void UpdateIdle()
    {
        timer += Time.deltaTime;
        if (timer > MovingDelay)
        {
            State = Define.CreatureState.Moving;
        }
    }
    protected virtual void FollowTree()
    {
        float speed;
        if (moveDir == Define.MoveDir.Right)
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
