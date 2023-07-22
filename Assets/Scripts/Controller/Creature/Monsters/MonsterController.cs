using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : CreatureController
{
    protected Rigidbody2D rigid;
    protected TreeController _target;
    protected Animator _animator;
    public Define.MonsterType type;
    public Define.MoveDir moveDir;
    public GameObject bulletPoint;
    GameObject icicle;
    public float MovingDelay = 100f;
    public float coin;
    public float originalSpeed;
    public float debuffTime = 3f;
    public float debuffMoveSpeed = 0.3f;
    public float bulletSpeed = 10f;
    public void DebuffMoveSpeed()
    {
        StartCoroutine(CoDebuffMoveSpeed());
    }
    IEnumerator CoDebuffMoveSpeed()
    {
        Stat.MoveSpeed = Stat.MoveSpeed - Stat.MoveSpeed * debuffMoveSpeed;
        yield return new WaitForSeconds(debuffTime);
        Stat.MoveSpeed = originalSpeed;
    }
    protected virtual void Init()
    {
        Stat = GetComponent<Stat>();
        _animator = GetComponent<Animator>();
        icicle = Managers.Resource.Load<GameObject>("Creature/Icicle");
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
        if (transform.childCount == 1)
            bulletPoint = transform.GetChild(0).gameObject;
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
                coin = Managers.Data.MonsterData[13];
                break;
            case Define.MonsterType.Fire:
                Stat.Hp = Managers.Data.MonsterData[15];
                Stat.Attack = Managers.Data.MonsterData[16];
                Stat.MoveSpeed = Managers.Data.MonsterData[17];
                Stat.AttackSpeed = Managers.Data.MonsterData[18];
                Stat.AttackRange = Managers.Data.MonsterData[19];
                coin = Managers.Data.MonsterData[20];
                break;
            case Define.MonsterType.Tank:
                Stat.Hp = Managers.Data.MonsterData[22];
                Stat.Attack = Managers.Data.MonsterData[23];
                Stat.MoveSpeed = Managers.Data.MonsterData[24];
                Stat.AttackSpeed = Managers.Data.MonsterData[25];
                Stat.AttackRange = Managers.Data.MonsterData[26];
                coin = Managers.Data.MonsterData[27];
                break;
            case Define.MonsterType.Fast:
                Stat.Hp = Managers.Data.MonsterData[29];
                Stat.Attack = Managers.Data.MonsterData[30];
                Stat.MoveSpeed = Managers.Data.MonsterData[31];
                Stat.AttackSpeed = Managers.Data.MonsterData[32];
                Stat.AttackRange = Managers.Data.MonsterData[33];
                coin = Managers.Data.MonsterData[34];
                break;
            case Define.MonsterType.Bomb:
                Stat.Hp = Managers.Data.MonsterData[36];
                Stat.Attack = Managers.Data.MonsterData[37];
                Stat.MoveSpeed = Managers.Data.MonsterData[38];
                Stat.AttackSpeed = Managers.Data.MonsterData[39];
                Stat.AttackRange = Managers.Data.MonsterData[40];
                coin = Managers.Data.MonsterData[41];
                break;
        }
        originalSpeed = Stat.MoveSpeed;
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
    bool isDetect = false;
    protected virtual void FollowTree()
    {
        if (type == Define.MonsterType.Fire && isDetect == false)
        {
            float distance = Mathf.Abs(_target.transform.position.x - transform.position.x);
            if (distance <= Stat.AttackRange)
            {
                isDetect = true;
                State = Define.CreatureState.Skill;
                rigid.bodyType = RigidbodyType2D.Static;
                StartCoroutine(CoFireAttack());
            }
        }
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
        if (Managers.Game.monsters.Count == 0)
            Managers.UI.ShowPopupUI<UI_ClearPopup>();
        Managers.Game.Crystal += (int)coin;
        base.OnDead();
    }
    protected IEnumerator CoCommonAttack()
    {
        _target.OnDamaged(Stat.Attack);
        //_animator.Play($"{type}_ATTACK");
        yield return new WaitForSeconds(Stat.AttackSpeed);
        StartCoroutine(CoCommonAttack());
    }
    // TODO
    protected IEnumerator CoBombAttack()
    {
        _target.OnDamaged(Stat.Attack);
        // TODO - 애니메이션 트리거 사용
        //_animator.Play($"{type}_ATTACK");
        Managers.Resource.Destroy(gameObject);
        yield return null;
    }
    protected IEnumerator CoFireAttack()
    {
        Fire();
        yield return new WaitForSeconds(Stat.AttackSpeed);
        StartCoroutine(CoFireAttack());
    }
    protected void Fire()
    {
        //_animator.Play($"{type}_ATTACK");
        IcicleController ic = Managers.Resource.Instantiate(icicle).GetComponent<IcicleController>();
        ic.transform.position = bulletPoint.transform.position;
        ic.bulletSpeed = bulletSpeed;
        ic.bulletAttack = Stat.Attack;
        ic.dir = moveDir;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Tree")
        {
            State = Define.CreatureState.Skill;
            switch (type)
            {
                case Define.MonsterType.Common:
                    StartCoroutine(CoCommonAttack());
                    break;
                case Define.MonsterType.Fast:
                    StartCoroutine(CoCommonAttack());
                    break;
                case Define.MonsterType.Tank:
                    StartCoroutine(CoCommonAttack());
                    break;
                case Define.MonsterType.Bomb:
                    StartCoroutine(CoBombAttack());
                    break;
                default:
                    break;
            }
        }
    }
}
