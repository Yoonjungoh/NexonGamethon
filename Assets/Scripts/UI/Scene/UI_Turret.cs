using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Turret : UI_Scene
{
    public SpawnPoint[] spawnPoints;
    List<GameObject> imageList = new List<GameObject>();
    bool isChoosing = false;
    string currentChooseTurretName;
    enum Buttons
    {
        SquirrelTurretButton,
        DeerTurretButton,
        OwlTurretButton
    }
    void Start()
    {
        Bind<Button>(typeof(Buttons));
        GetButton((int)Buttons.SquirrelTurretButton).onClick.AddListener(() => BuyTurret("SquirrelTurretImage"));
        GetButton((int)Buttons.DeerTurretButton).onClick.AddListener(() => BuyTurret("DeerTurretImage"));
        GetButton((int)Buttons.OwlTurretButton).onClick.AddListener(() => BuyTurret("OwlTurretImage"));
        GameObject[] gos = GameObject.FindGameObjectsWithTag("SpawnPoint");
        spawnPoints = new SpawnPoint[gos.Length]; 
        for (int i = 0; i < gos.Length; i++)
            spawnPoints[i] = new SpawnPoint(gos[i], false);
        Managers.Game.SpawnPoints = spawnPoints;
    }
    void BuyTurret(string name)
    {
        // �̹� ���� �ִ� �ͷ� ��ư �ٽ� ���� ���
        if (GameObject.Find($"{name}"))
        {
            foreach (GameObject go in imageList)
            {
                Managers.Resource.Destroy(go);
            }
        }
        // �̹� ���� �ִ� �ͷ� ��ư�� �ƴ� �ٸ� �ͷ� ��ư�� ���� ���
        else if (imageList.Count > 0)
        {
            // ���� �� ���� ���� �� ���� �����ɷ� ����
            foreach (GameObject go in imageList)
            {
                Managers.Resource.Destroy(go);
            }
            for (int i = 0; i < Managers.Game.SpawnPoints.Length; i++)
            {
                if (Managers.Game.SpawnPoints[i].IsFull == false)
                {
                    currentChooseTurretName = name;
                    GameObject g = Managers.Resource.Instantiate($"Turret/Images/{name}");
                    imageList.Add(g);
                    g.transform.position = Managers.Game.SpawnPoints[i].spawnPoint.transform.position + Vector3.up;
                }
            }
        }
        // �ͷ� ��ư�� ó������ ���� ���
        else
        {
            for (int i = 0; i < Managers.Game.SpawnPoints.Length; i++)
            {
                if (Managers.Game.SpawnPoints[i].IsFull == false)
                {
                    currentChooseTurretName = name;
                    GameObject g = Managers.Resource.Instantiate($"Turret/Images/{name}");
                    imageList.Add(g);
                    g.transform.position = Managers.Game.SpawnPoints[i].spawnPoint.transform.position + Vector3.up;
                }
            }
        }
    }
}
public class SpawnPoint
{
    public GameObject spawnPoint;
    public bool IsFull;
    public SpawnPoint(GameObject go, bool isFull)
    {
        spawnPoint = go;
        IsFull = isFull;
    }
}
