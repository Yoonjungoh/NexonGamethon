using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speed = 15f;
    private int doubleSpeed = 4;
    private float maxDistance = 31.5f;
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (transform.position.x > -maxDistance)
                transform.position -= new Vector3(Time.deltaTime * speed, 0, 0);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            if (transform.position.x < maxDistance)
                transform.position += new Vector3(Time.deltaTime * speed, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.P))
            Time.timeScale *= doubleSpeed;
        if (Input.GetKeyUp(KeyCode.P))
            Time.timeScale /= doubleSpeed;
    }
}
