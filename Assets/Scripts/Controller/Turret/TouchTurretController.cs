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
        string turretName = (gameObject.name).Substring(0, gameObject.name.Length - 5);
        TurretController tc = Managers.Resource.Load<GameObject>($"Turret/{turretName}").GetComponent<TurretController>();

        if (Managers.Game.Crystal >= tc.cost[tc.level - 1])
        {
            Managers.Game.Crystal -= (int)tc.cost[tc.level - 1];
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
            GameObject turret = Managers.Resource.Instantiate($"Turret/{turretName}");
            turret.transform.position = transform.position;
            Managers.Resource.Destroy(gameObject);
        }
        else
        {
            Debug.Log("µ· ºÎÁ·");
        }
    }
}