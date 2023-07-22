using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stat : MonoBehaviour
{
    public float Hp;
    public float Attack;
    public float MoveSpeed;
    public float AttackSpeed;
    public float AttackRange;
    public float Cost;
    public Stat(float hp, float attack, float moveSpeed, float attackSpeed, float attackRange)
    {
        Hp = hp;
        Attack = attack;
        MoveSpeed = moveSpeed;
        AttackSpeed = attackSpeed;
        AttackRange = attackRange;
    }
    public Stat()
    {

    }
}
