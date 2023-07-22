using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TurretShop: MonoBehaviour
{
    private int[] num_gold_list;
    private int[] click_gold_list;
    private Text[] turretPrice;

    public Text[] turrentPriceTxt;
    public Text[] turretLvTxt;
    public Button[] turretBtn;
    public GameObject[] lockPanel;
    public ShopUISystem shopUISystem;
    //public Sprite[] levelImages;

    private int stageLevel;
    private int num_level;
    private int click_level;
    private int turrentPrice;

    private void Awake()
    {
        stageLevel = Managers.Game.stageLevel;

        for (int i = 0; i < 4; i++)
        {
            if (Managers.Game.turret_Lv[i]>=3)
            {
                turretLvTxt[i].text = "LV."+(Managers.Game.turret_Lv[i]).ToString();
                turrentPriceTxt[i].text = "";
            }
            else
            {
                turretLvTxt[i].text=(Managers.Game.turret_Lv[i]+1).ToString();
                Debug.Log(Managers.Game.turret_Lv[i]);
                Debug.Log(Managers.Game.turretPrices[i, Managers.Game.turret_Lv[i]]);
                turrentPriceTxt[i].text = Managers.Game.turretPrices[i, Managers.Game.turret_Lv[i]].ToString();
            }
        }
        if (stageLevel <= 3)
        {
            for(int i = stageLevel; i<4; i++)
            {
                lockPanel[i].SetActive(true);
                turretLvTxt[i].text = "LV.0";
            }
        }      
    }

    private void Start()
    {
        Debug.Log(Managers.Data.TurretData.Count);
        Debug.Log(Managers.Game.coin);
        Debug.Log(Managers.Game.turretPrices);
    }
    public void TurretUpgrade(int turretNum)
    {
        //터렛 레벨 3이상이면 리턴
        if (Managers.Game.turret_Lv[turretNum] >= 3) return;
        //코인 부족하면 리턴
        turrentPrice = Managers.Game.turretPrices[turretNum, Managers.Game.turret_Lv[turretNum]];
        if (Managers.Game.coin < turrentPrice) return;

        //재화 계산
        shopUISystem.SetCoin(-turrentPrice);
        //레벨 업
        Managers.Game.turret_Lv[turretNum] += 1;
        //text
        if(Managers.Game.turret_Lv[turretNum] >= 3)
        {
            turrentPriceTxt[turretNum].text = " ";
        }
        else
        {
            turretLvTxt[turretNum].text = "LV." + (Managers.Game.turret_Lv[turretNum] + 1).ToString();
            turrentPriceTxt[turretNum].text = Managers.Game.turretPrices[turretNum, Managers.Game.turret_Lv[turretNum]].ToString();
        }
        Debug.Log("coin" + Managers.Game.coin);
    }
    public void Reset()
    {
        stageLevel = Managers.Game.stageLevel;
        if (stageLevel <= 3)
        {
            for (int i = stageLevel; i < 4; i++)
            {
                lockPanel[i].SetActive(true);
                //turretBtn[3-i].gameObject.SetActive(false);
                turretLvTxt[i].text = "LV.0";
            }
        }
        for(int i =0; i< 4; i++)
        {
            Managers.Game.turret_Lv[i]=0;
        }
    }
    private void SetImageLevel(int idx)
    {
        for (int i = 0; i < 3; i++)
        {
            //images[i].SetActive(true);
        }
    }

}
