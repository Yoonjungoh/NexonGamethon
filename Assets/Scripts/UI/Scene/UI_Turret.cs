using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Turret : UI_Scene
{
    GameObject[] spawnPoints;
    List<GameObject> imageList = new List<GameObject>();
    enum Buttons
    {
        SingleTurretButton,
        MultiTurretButton,
    }
    void Start()
    {
        Bind<Button>(typeof(Buttons));
        GetButton((int)Buttons.SingleTurretButton).onClick.AddListener(BuySingleTurret);
        GetButton((int)Buttons.MultiTurretButton).onClick.AddListener(BuyMultiTurret);
        spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
    }
    void BuySingleTurret()
    {
        if (GameObject.Find("SingleTurretImage"))
        {
            foreach (GameObject go in imageList)
            {
                Managers.Resource.Destroy(go);
            }
        }
        else
        {
            foreach (GameObject go in spawnPoints)
            {
                GameObject g = Managers.Resource.Instantiate("Turret/Images/SingleTurretImage");
                imageList.Add(g);
                g.transform.position = go.transform.position + Vector3.up;
            }
        }
    }
    void BuyMultiTurret()
    {
        if (GameObject.Find("MultiTurretImage"))
        {
            foreach (GameObject go in imageList)
            {
                Managers.Resource.Destroy(go);
            }
        }
        else
        {
            foreach (GameObject go in spawnPoints)
            {
                GameObject g = Managers.Resource.Instantiate("Turret/Images/MultiTurretImage");
                imageList.Add(g);
                g.transform.position = go.transform.position + Vector3.up;
            }
        }
    }
}
