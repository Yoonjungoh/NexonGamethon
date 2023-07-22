using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    public Define.TurretType type;
    protected Animator animator;
    public Stat Stat;
    protected float fireTimer = 0f;
    protected float fireDelay = 1f;
    public float[] cost = new float[3];
    public int level = 1;
    public float bulletSpeed = 30;
    protected List<GameObject> bulletPoints = new List<GameObject>();
    protected GameObject bullet;
    protected float perIncreaseAttack;
    protected virtual void Init()
    {
        animator = GetComponent<Animator>();
        bulletSpeed = 30;
        string turretName = (gameObject.name).Substring(0, gameObject.name.Length - 5);
        Stat = new Stat();
        InitStat();
        InitBulletPoint();
        bullet = Managers.Resource.Load<GameObject>($"Creature/Bullet/{type}Bullet");
        fireDelay = Stat.AttackSpeed;
    }
    protected virtual void InitBulletPoint()
    {
        if (type != Define.TurretType.Bear)
        {
            bulletPoints.Add(transform.GetChild(0).gameObject);
        }
        else
        {
            bulletPoints.Add(transform.GetChild(0).gameObject);
            bulletPoints.Add(transform.GetChild(1).gameObject);
            bulletPoints.Add(transform.GetChild(2).gameObject);
            bulletPoints.Add(transform.GetChild(3).gameObject);
            bulletPoints.Add(transform.GetChild(4).gameObject);
        }
    }
    protected virtual void UpdateController()
    {

        fireTimer += Time.deltaTime;
        // x축 우선 탐색
        if (fireTimer >= fireDelay)
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, Stat.AttackRange);
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].tag == "Monster")
                {
                    MonsterController monster = FindMonster();
                    if (monster != null)
                    {
                        Fire(monster);
                        fireTimer = 0f;
                    }
                    break;
                }
            }
        }
    }
    protected MonsterController FindMonster()
    {
        float minX = float.MaxValue;
        MonsterController target = null;
        foreach (MonsterController monster in Managers.Game.monsters)
        {
            float value = Mathf.Abs(transform.position.x - monster.transform.position.x);
            if (minX > value)
            {
                minX = value;
                target = monster;
            }
        }
        return target;
    }
    protected virtual void Fire(MonsterController monster)
    {
        if (type != Define.TurretType.Bear)
        {
            BulletController bc = Managers.Resource.Instantiate(bullet).GetComponent<BulletController>();
            bc.transform.position = bulletPoints[0].transform.position;
            bc.target = monster;
            bc.targetPosition = monster.transform.position;
            bc.Owner = this;
            bc.bulletSpeed = bulletSpeed;
            // 방향 처리
            Vector3 direction = monster.transform.position - transform.position;
            direction.z = 0f;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            bc.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle - 90f));
        }
        // 곰 일 때 산탄 처리
        else
        {
            BulletController bc = Managers.Resource.Instantiate(bullet).GetComponent<BulletController>();
            bc.transform.position = bulletPoints[0].transform.position;
            bc.target = monster;
            bc.targetPosition = monster.transform.position;
            bc.Owner = this;
            bc.bulletSpeed = bulletSpeed;
            // 방향 처리
            Vector3 direction = monster.transform.position - transform.position;
            direction.z = 0f;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            bc.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle - 90f));

            for (int i = 1; i < 5; i++)
            {
                float value = 0f;
                if (i == 1)
                    value = 10;
                else if (i == 2)
                    value = -10;
                else if (i == 3)
                    value = 20;
                else if (i == 4)
                    value = -20;
                // angle 값을 라디안으로 변환
                float radians = (angle + value) * Mathf.Deg2Rad;
                // direction 벡터를 계산
                Vector2 dir = new Vector2(Mathf.Cos(radians), Mathf.Sin(radians));
                BulletController b = Managers.Resource.Instantiate(bullet).GetComponent<BulletController>();
                b.transform.position = bulletPoints[0].transform.position;
                b.Owner = this;
                b.bulletSpeed = bulletSpeed;
                b.direction = dir;
                b.targetPosition = Vector3.zero;
                // 방향 처리
                b.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle + value - 90f));
            }
        }
    }
    protected void InitStat()
    {
        switch (type)
        {
            case Define.TurretType.Squirrel:
                perIncreaseAttack = 1;
                Stat.Attack = Managers.Data.TurretData[9];
                Stat.Attack += perIncreaseAttack * (Managers.Game.turret_Lv[0] - 1);
                Stat.AttackSpeed = Managers.Data.TurretData[10];
                Stat.AttackRange = Managers.Data.TurretData[11];
                cost[0] = Managers.Data.TurretData[13];
                cost[1] = Managers.Data.TurretData[14];
                cost[2] = Managers.Data.TurretData[15];
                break;
            case Define.TurretType.Owl:
                perIncreaseAttack = 40;
                Stat.Attack = Managers.Data.TurretData[17];
                Stat.Attack += perIncreaseAttack * (Managers.Game.turret_Lv[1] - 1);
                Stat.AttackSpeed = Managers.Data.TurretData[18];
                Stat.AttackRange = Managers.Data.TurretData[19];
                cost[0] = Managers.Data.TurretData[21];
                cost[1] = Managers.Data.TurretData[22];
                cost[2] = Managers.Data.TurretData[23];
                break;
            case Define.TurretType.Deer:
                perIncreaseAttack = 10;
                Stat.Attack = Managers.Data.TurretData[25];
                Stat.Attack += perIncreaseAttack * (Managers.Game.turret_Lv[2] - 1);
                Stat.AttackSpeed = Managers.Data.TurretData[26];
                Stat.AttackRange = Managers.Data.TurretData[27];
                cost[0] = Managers.Data.TurretData[29];
                cost[1] = Managers.Data.TurretData[30];
                cost[2] = Managers.Data.TurretData[31];
                break;
            case Define.TurretType.Bear:
                perIncreaseAttack = 15;
                Stat.Attack = Managers.Data.TurretData[33];
                Stat.Attack += perIncreaseAttack * (Managers.Game.turret_Lv[3] - 1);
                Stat.AttackSpeed = Managers.Data.TurretData[34];
                Stat.AttackRange = Managers.Data.TurretData[35];
                cost[0] = Managers.Data.TurretData[37];
                cost[1] = Managers.Data.TurretData[38];
                cost[2] = Managers.Data.TurretData[39];
                break;
        }

    }
    private void OnDrawGizmos()
    {
        try
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, Stat.AttackRange);
        }
        catch (Exception e)
        {

        }
    }
}
