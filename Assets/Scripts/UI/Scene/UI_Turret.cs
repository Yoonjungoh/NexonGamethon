using System.Collections;
using System.Collections.Generic;
using TMPro;
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
        OwlTurretButton,
        BearTurretButton
    }
    enum Texts
    {
        SquirrelCostText,
        DeerCostText,
        OwlCostText,
        BearCostText
    }
    void Start()
    {
        // 터렛 코스트 초기화
        Managers.Game.SquirrelCost = new float[] { Managers.Data.TurretData[13], Managers.Data.TurretData[14], Managers.Data.TurretData[15] };
        Managers.Game.OwlCost = new float[] { Managers.Data.TurretData[21], Managers.Data.TurretData[22], Managers.Data.TurretData[23] };
        Managers.Game.DeerCost = new float[] { Managers.Data.TurretData[29], Managers.Data.TurretData[30], Managers.Data.TurretData[31] };
        Managers.Game.BearCost = new float[] { Managers.Data.TurretData[37], Managers.Data.TurretData[38], Managers.Data.TurretData[39] };

        Bind<Button>(typeof(Buttons));
        Bind<TextMeshProUGUI>(typeof(Texts));

        GetButton((int)Buttons.SquirrelTurretButton).onClick.AddListener(() => BuyTurret("SquirrelTurretImage"));
        GetButton((int)Buttons.DeerTurretButton).onClick.AddListener(() => BuyTurret("DeerTurretImage"));
        GetButton((int)Buttons.OwlTurretButton).onClick.AddListener(() => BuyTurret("OwlTurretImage"));
        GetButton((int)Buttons.BearTurretButton).onClick.AddListener(() => BuyTurret("BearTurretImage"));

        if (Managers.Game.turret_Lv[0] == 0)
        {
            GetButton((int)Buttons.SquirrelTurretButton).interactable = false; 
            GetTextMeshProUGUI((int)Texts.SquirrelCostText).text = $"X";
        }
        else
            GetTextMeshProUGUI((int)Texts.SquirrelCostText).text = $"{Managers.Game.SquirrelCost[Managers.Game.turret_Lv[0] - 1]}";
        
        if (Managers.Game.turret_Lv[1] == 0)
        {
            GetButton((int)Buttons.OwlTurretButton).interactable = false;
            GetTextMeshProUGUI((int)Texts.OwlCostText).text = $"X";
        }
        else
            GetTextMeshProUGUI((int)Texts.OwlCostText).text = $"{Managers.Game.OwlCost[Managers.Game.turret_Lv[1] - 1]}";
        
        if (Managers.Game.turret_Lv[2] == 0)
        {
            GetButton((int)Buttons.DeerTurretButton).interactable = false;
            GetTextMeshProUGUI((int)Texts.DeerCostText).text = $"X";
        }
        else
            GetTextMeshProUGUI((int)Texts.DeerCostText).text = $"{Managers.Game.DeerCost[Managers.Game.turret_Lv[2] - 1]}";
        
        if (Managers.Game.turret_Lv[3] == 0)
        {
            GetButton((int)Buttons.BearTurretButton).interactable = false;
            GetTextMeshProUGUI((int)Texts.BearCostText).text = $"X";
        }
        else
            GetTextMeshProUGUI((int)Texts.BearCostText).text = $"{Managers.Game.BearCost[Managers.Game.turret_Lv[3] - 1]}";

        GameObject[] gos = GameObject.FindGameObjectsWithTag("SpawnPoint");
        spawnPoints = new SpawnPoint[gos.Length]; 
        for (int i = 0; i < gos.Length; i++)
            spawnPoints[i] = new SpawnPoint(gos[i], false);
        Managers.Game.SpawnPoints = spawnPoints;
        InitCards();
    }
    void InitCards()
    {
        // 다람쥐
        if (Managers.Game.turret_Lv[0] == 1)
        {
            GetButton((int)Buttons.SquirrelTurretButton).image.sprite = Managers.Resource.Load<Sprite>("A_S_0");
        }
        else if (Managers.Game.turret_Lv[0] == 2)
        {
            GetButton((int)Buttons.SquirrelTurretButton).image.sprite = Managers.Resource.Load<Sprite>("A_S_1");
        }
        else if (Managers.Game.turret_Lv[0] == 3)
        {
            GetButton((int)Buttons.SquirrelTurretButton).image.sprite = Managers.Resource.Load<Sprite>("A_S_2");
        }

        // 올빼미
        if (Managers.Game.turret_Lv[1] == 1)
        {
            GetButton((int)Buttons.OwlTurretButton).image.sprite = Managers.Resource.Load<Sprite>("A_O_0");
        }
        else if (Managers.Game.turret_Lv[1] == 2)
        {
            GetButton((int)Buttons.OwlTurretButton).image.sprite = Managers.Resource.Load<Sprite>("A_O_1");
        }
        else if (Managers.Game.turret_Lv[1] == 3)
        {
            GetButton((int)Buttons.OwlTurretButton).image.sprite = Managers.Resource.Load<Sprite>("A_O_2");
        }

        // 사슴
        if (Managers.Game.turret_Lv[2] == 1)
        {
            GetButton((int)Buttons.DeerTurretButton).image.sprite = Managers.Resource.Load<Sprite>("A_T_0");
        }
        else if (Managers.Game.turret_Lv[2] == 2)
        {
            GetButton((int)Buttons.DeerTurretButton).image.sprite = Managers.Resource.Load<Sprite>("A_T_1");
        }
        else if (Managers.Game.turret_Lv[2] == 3)
        {
            GetButton((int)Buttons.DeerTurretButton).image.sprite = Managers.Resource.Load<Sprite>("A_T_2");
        }

        // 곰
        if (Managers.Game.turret_Lv[3] == 1)
        {
            GetButton((int)Buttons.BearTurretButton).image.sprite = Managers.Resource.Load<Sprite>("A_B_0");
        }
        else if (Managers.Game.turret_Lv[3] == 2)
        {
            GetButton((int)Buttons.BearTurretButton).image.sprite = Managers.Resource.Load<Sprite>("A_B_1");
        }
        else if (Managers.Game.turret_Lv[3] == 3)
        {
            GetButton((int)Buttons.BearTurretButton).image.sprite = Managers.Resource.Load<Sprite>("A_B_2");
        }
    }
    void BuyTurret(string name)
    {
        // 이미 눌려 있는 터렛 버튼 다시 누른 경우
        if (GameObject.Find($"{name}"))
        {
            foreach (GameObject go in imageList)
            {
                Managers.Resource.Destroy(go);
            }
        }
        // 이미 눌려 있는 터렛 버튼이 아닌 다른 터렛 버튼을 누른 경우
        else if (imageList.Count > 0)
        {
            // 기존 꺼 전부 제거 후 새로 누른걸로 생성
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
        // 터렛 버튼을 처음으로 누른 경우
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
