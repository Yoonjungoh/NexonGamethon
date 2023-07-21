using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureController : MonoBehaviour
{
    public Stat Stat;
    public Define.CreatureState State;
    virtual public float OnDamaged(float damage)
    {
        Stat.Hp -= damage;
        if (Stat.Hp <= 0)
        {
            Stat.Hp = 0;
            State = Define.CreatureState.Dead;
        }
        return damage;
    }
}
