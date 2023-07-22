using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchTurretController : MonoBehaviour
{
    GameObject[] images;
    UI_Turret turretUI;
    private void OnMouseDown()
    {
        string turretName = (gameObject.name).Substring(0, gameObject.name.Length - 5);
        TurretController tc = Managers.Resource.Load<GameObject>($"Turret/{turretName}").GetComponent<TurretController>();
        float cost = 0f;
        if (tc.type == Define.TurretType.Squirrel)
        {
            cost = Managers.Game.SquirrelCost[Managers.Game.SquirrelTurretLevel - 1];
        }
        else if (tc.type == Define.TurretType.Owl)
        {
            cost = Managers.Game.OwlCost[Managers.Game.OwlTurretLevel - 1];
        }
        else if (tc.type == Define.TurretType.Deer)
        {
            cost = Managers.Game.DeerCost[Managers.Game.DeerTurretLevel - 1];
        }
        else if (tc.type == Define.TurretType.Bear)
        {
            cost = Managers.Game.BearCost[Managers.Game.BearTurretLevel - 1];
        }
        if (Managers.Game.Crystal >= cost)
        {
            Managers.Game.Crystal -= (int)cost;
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