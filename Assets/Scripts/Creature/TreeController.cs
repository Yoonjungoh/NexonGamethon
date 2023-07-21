using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeController : CreatureController
{
    void Start()
    {
        // �������� ���� �������� ���� ����� ������
         Stat = new Stat(Managers.Data.TreeData[4], Managers.Data.TreeData[5], Managers.Data.TreeData[6], Managers.Data.TreeData[7]);

        // ����Ʈ State Idle�� �ٲ�
        State = Define.CreatureState.Idle;
    }
    public override float OnDamaged(float damage)
    {
        base.OnDamaged(damage);
        GameObject go = Managers.Resource.Instantiate("DamageText");
        go.GetComponent<DamageTextController>().damage = damage;
        go.transform.position = new Vector3(transform.position.x, transform.position.y + 0.3f, 0);
        Debug.Log("���� ü��: " + Stat.Hp);
        return damage;
    }
}
