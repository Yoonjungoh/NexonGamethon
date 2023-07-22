using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    protected Define.TurretType type;
    protected Animator animator;
    public Stat Stat;
    protected float fireTimer = 0f;
    protected float fireDelay = 1f;
    protected float[] cost = new float[3];
    public float bulletSpeed = 30;
    protected GameObject[] bulletPoints;

    protected virtual void Init()
    {
        animator = GetComponent<Animator>();
        bulletSpeed = 30;
        string turretName = (gameObject.name).Substring(0, gameObject.name.Length - 5);
        Stat = new Stat();
        InitStat();
        InitBulletPoint();
        fireDelay = Stat.AttackSpeed;
    }
    protected virtual void InitBulletPoint()
    {
        bulletPoints = GameObject.FindGameObjectsWithTag("BulletPoint");
    }
    protected virtual void UpdateController()
    {

        fireTimer += Time.deltaTime;
        // x√‡ øÏº± ≈Ωªˆ
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
        BulletController bc = Managers.Resource.Instantiate("Creature/Bullet").GetComponent<BulletController>();
        if (type != Define.TurretType.Bear)
        {
            bc.transform.position = bulletPoints[0].transform.position;
            bc.target = monster;
            bc.targetPosition = monster.transform.position;
            bc.Owner = this;
            bc.bulletSpeed = bulletSpeed;
        }
        // ∞ı ¿œ ∂ß ªÍ≈∫ √≥∏Æ
        else
        {

        }
    }
    protected void InitStat()
    {
        switch (type)
        {
            case Define.TurretType.Squirrel:
                Stat.Attack = Managers.Data.TurretData[9];
                Stat.AttackSpeed = Managers.Data.TurretData[10];
                Stat.AttackRange = Managers.Data.TurretData[11];
                cost[0] = Managers.Data.TurretData[13];
                cost[1] = Managers.Data.TurretData[14];
                cost[2] = Managers.Data.TurretData[15];
                break;
            case Define.TurretType.Owl:
                Stat.Attack = Managers.Data.TurretData[17];
                Stat.AttackSpeed = Managers.Data.TurretData[18];
                Stat.AttackRange = Managers.Data.TurretData[19];
                cost[0] = Managers.Data.TurretData[21];
                cost[1] = Managers.Data.TurretData[22];
                cost[2] = Managers.Data.TurretData[23];
                break;
            case Define.TurretType.Deer:
                Stat.Attack = Managers.Data.TurretData[25];
                Stat.AttackSpeed = Managers.Data.TurretData[26];
                Stat.AttackRange = Managers.Data.TurretData[27];
                cost[0] = Managers.Data.TurretData[29];
                cost[1] = Managers.Data.TurretData[30];
                cost[2] = Managers.Data.TurretData[31];
                break;
            case Define.TurretType.Bear:
                Stat.Attack = Managers.Data.TurretData[33];
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
