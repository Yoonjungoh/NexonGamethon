using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public TurretController Owner;
    public float bulletSpeed = 10f; // �Ѿ��� �ӵ�
    public Vector3 targetPosition = Vector3.zero;
    public MonsterController target;
    Rigidbody2D rigid;
    public Vector3 direction;
    public float disappearTime = 3f;
    public List<MonsterController> monsters = new List<MonsterController>();
    public bool isStop = false;
    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        if (targetPosition != Vector3.zero)
            direction = (targetPosition - transform.position).normalized;

    }
    private void Update()
    {
        if (target == null)
        {
            // �Ѿ��� ������ ���
            rigid.velocity = direction * bulletSpeed;
        }
        if (isStop == false)
            rigid.velocity = direction * bulletSpeed;
    }
    IEnumerator CoDestroyBullet()
    {
        yield return new WaitForSeconds(disappearTime);
        Managers.Resource.Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            isStop = true;
            // �罿 �Ѿ��� ���ο�
            if (Owner.type == Define.TurretType.Deer)
            {
                rigid.velocity = Vector2.zero;
                rigid.bodyType = RigidbodyType2D.Static;
                StartCoroutine(CoDestroyBullet());
            }
            else
            {
                Managers.Resource.Destroy(gameObject);
            }
        }
        if (collision.tag == "Monster")
        {
            MonsterController monster = collision.GetComponent<MonsterController>();
            // �罿 �Ѿ��� ���ο�
            if (Owner.type == Define.TurretType.Deer)
            {
                monster.OnDamaged(Owner.Stat.Attack);
                monster.DebuffMoveSpeed();
            }
            else
            {
                monster.OnDamaged(Owner.Stat.Attack);
                Managers.Resource.Destroy(gameObject);
            }
        }
    }
}
