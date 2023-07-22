using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchTurretController : MonoBehaviour
{
    GameObject[] images;
    UI_Turret turretUI;
    void Start()
    {
    }
    private void OnMouseDown()
    {
        for (int i = 0; i < Managers.Game.SpawnPoints.Length; i++)
        {
            if (Managers.Game.SpawnPoints[i].spawnPoint.transform.position + Vector3.up == gameObject.transform.position)
            {
                Managers.Game.SpawnPoints[i].IsFull = true;
                break;
            }
        }
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