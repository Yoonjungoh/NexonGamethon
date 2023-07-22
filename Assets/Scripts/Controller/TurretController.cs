using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    Define.TurretType type;
    public Stat Stat;
    float fireTimer = 0f;
    float fireDelay = 1f;
    float cost = 0;
    public float bulletSpeed = 30;
    void Start()
    {
        bulletSpeed = 30;
        string turretName = (gameObject.name).Substring(0, gameObject.name.Length - 5);
        Stat = new Stat();
        Stat.Attack = Managers.Data.TurretData[9];
        Stat.AttackSpeed = Managers.Data.TurretData[10];
        Stat.AttackRange = Managers.Data.TurretData[11];
        fireDelay = Stat.AttackSpeed;
    }
    void Update()
    {
        fireTimer += Time.deltaTime;
        // xÃà ¿ì¼± Å½»ö
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
    MonsterController FindMonster()
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
        bc.transform.position = transform.position;
        bc.target = monster;
        bc.targetPosition = monster.transform.position;
        bc.Owner = this;
        bc.bulletSpeed = bulletSpeed;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Stat.AttackRange);
    }
}
