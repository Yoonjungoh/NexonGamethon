using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcicleController : MonoBehaviour
{
    public float bulletSpeed;
    public float bulletAttack;
    public Define.MoveDir dir;
    public Rigidbody2D rigid;
    int dirVector;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        if (dir == Define.MoveDir.Right)
        {
            dirVector = 1;
            transform.eulerAngles = new Vector3(0, 0, -90);
        }
        else
        {
            dirVector = -1;
            transform.eulerAngles = new Vector3(0, 0, 90);
        }
    }

    // Update is called once per frame
    void Update()
    {
        rigid.AddForce(new Vector2(dirVector * bulletSpeed * Time.deltaTime, 0f));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Tree")
        {
            collision.GetComponent<TreeController>().OnDamaged(bulletAttack);
            Managers.Resource.Destroy(gameObject);
        }
    }
}
