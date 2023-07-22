using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopUISystem : MonoBehaviour
{
    //public GameObject branchShop;
    //public GameObject turretShop;
    //public GameObject treeLevelShop; 
    public TMP_Text coinTxt;

    private void Awake()
    {
        coinTxt.text = Managers.Game.coin.ToString();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetAll()
    {
        //���¹�ư 
        //turretShop.GetComponent<TurretShop>().Reset();   
        //treeLevelShop.GetComponent<TreeLevelShop>().Reset();
        //branchShop.GetComponent<BranchShop>().Reset();

        Managers.Game.paidCoin = 0;

    }

    public void StartGame()
    {
        //���ӽ��۹�ư
        Managers.Scene.LoadScene("Scene1");
    }
    public void SetCoin(int addCoin)
    {
        Managers.Game.coin += addCoin;
        coinTxt.text = Managers.Game.coin.ToString();
    }
}
