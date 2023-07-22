using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speed = 3f;
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position -= new Vector3(Time.deltaTime * speed, 0, 0);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(Time.deltaTime * speed, 0, 0);
        }
    }
}
