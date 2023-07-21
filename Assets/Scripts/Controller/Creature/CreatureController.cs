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
            OnDead();
        }
        GameObject go = Managers.Resource.Instantiate("DamageText");
        go.GetComponent<DamageTextController>().damage = damage;
        go.transform.position = new Vector3(transform.position.x, transform.position.y + 0.3f, 0);
        return damage;
    }
    virtual public void OnDead()
    {
        Managers.Resource.Destroy(gameObject);
    }
}
