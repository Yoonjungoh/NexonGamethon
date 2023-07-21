using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchTurretController : MonoBehaviour
{
    GameObject[] images;
    private void OnMouseDown()
    {
        images = GameObject.FindGameObjectsWithTag("TurretImage");
        foreach (GameObject go in images)
        {
            if (go != gameObject)
                Managers.Resource.Destroy(go);
        }
        string turretName = (gameObject.name).Substring(0, gameObject.name.Length - 5);
        GameObject turret = Managers.Resource.Instantiate($"Turret/{turretName}");
        turret.transform.position = transform.position;
        Managers.Resource.Destroy(gameObject);
    }
}