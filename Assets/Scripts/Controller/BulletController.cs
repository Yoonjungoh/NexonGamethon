using System.Collections;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public TurretController Owner;
    public float bulletSpeed = 10f; // 총알의 속도
    public Vector3 targetPosition = Vector3.zero;
    public MonsterController target;
    Rigidbody2D rigid;
    Vector3 direction;
    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        direction = (targetPosition - transform.position).normalized;
    }
    private void Update()
    {
        if (target == null)
        {
            // 총알의 방향을 계산
            rigid.velocity = direction * bulletSpeed;
        }
        if (targetPosition != Vector3.zero)
            ShootTowardsTarget();
    }
    public void ShootTowardsTarget()
    {
        // 총알의 방향을 계산
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
