using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : CreatureController
{
    Rigidbody2D rigid;
    TreeController _target;
    void Start()
    {
        // �������� ���� �������� ���� ����� ������
        if (Managers.Game.LoadCompleted == true)
            Stat = new Stat(Managers.Data.MonsterData[7], Managers.Data.MonsterData[8], Managers.Data.MonsterData[9], Managers.Data.MonsterData[10], Managers.Data.MonsterData[11]);
        else
            Stat = new Stat(10, 10, 10, 10, 10);

        rigid = GetComponent<Rigidbody2D>();
        _target = GameObject.Find("Tree").GetComponent<TreeController>();
        // ����Ʈ State Moving���� �ٲ�
        State = Define.CreatureState.Moving;
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Tree")
        {
            State = Define.CreatureState.Skill;
            _target.OnDamaged(Stat.Attack);
        }
    }
}
