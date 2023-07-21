using System.Collections;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public TurretController Owner;
    public float bulletSpeed = 10f; // �Ѿ��� �ӵ�
    public Vector3 targetPosition = Vector3.zero;
    Rigidbody2D rigid;
    private void Update()
    {
        if (targetPosition == Vector3.zero)
            Managers.Resource.Destroy(gameObject);
        if (targetPosition != Vector3.zero)
            ShootTowardsTarget();
    }
    public void ShootTowardsTarget()
    {
        // �Ѿ��� ������ ���
        Vector3 direction = (targetPosition - transform.position).normalized;

        rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = direction * bulletSpeed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            Managers.Resource.Destroy(gameObject);
        }
        if (collision.tag == "Monster")
        {
            collision.GetComponent<MonsterController>().OnDamaged(Owner.Stat.Attack);
            Managers.Resource.Destroy(gameObject);
        }
    }
}
