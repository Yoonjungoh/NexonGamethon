using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    Define.TurretType type;
    public Stat Stat = new Stat();
    float fireTimer = 0f;
    float fireDelay = 1f;
    void Start()
    {
        string turretName = (gameObject.name).Substring(0, gameObject.name.Length - 5);
        Stat.Attack = Managers.Data.TurretData[9];
        Stat.AttackSpeed = Managers.Data.TurretData[10];
        Stat.AttackRange = Managers.Data.TurretData[11];
        //Stat = new Stat(1, 1, 1, 1, 15);
    }
    void Update()
    {
        fireTimer += Time.deltaTime;
        //// ¿øÀ¸·Î Å½»ö
        //Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, Stat.AttackRange);
        //for (int i = 0; i < colliders.Length; i++)
        //{
        //    if (colliders[i].tag == "Monster" && fireTimer >= fireDelay)
        //    {
        //        Fire(colliders[i].transform.position);
        //        fireTimer = 0f;
        //        break;
        //    }
        //}
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
                        Fire(monster.transform.position);
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
    protected virtual void Fire(Vector3 targetPosition)
    {
        BulletController bc = Managers.Resource.Instantiate("Creature/Bullet").GetComponent<BulletController>();
        bc.transform.position = transform.position;
        bc.targetPosition = targetPosition;
        bc.Owner = this;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Stat.AttackRange);
    }
}
