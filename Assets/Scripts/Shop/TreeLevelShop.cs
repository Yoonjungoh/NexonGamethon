using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TreeLevelShop : MonoBehaviour
{
    public Button btn;
    public ShopUISystem shopUISystem;
    public GameObject popup;
    private Animator popupAnimator;
    public GameObject[] popupImage;

    private int _treeLevel;

    public void Awake()
    {
        popupAnimator = popup.GetComponent<Animator>();
    }

    public void ShowPopup(int idx)
    {
        //���� ���� 2 �̻��̸� ����
        if (Managers.Game.treeLevel >= 2) return;

        if (Managers.Game.treeLevel == 0)
        {
            popupImage[Managers.Game.treeLevel].SetActive(true);
            popupImage[1 - Managers.Game.treeLevel].SetActive(false);
        }
        else
        {
            popupImage[Managers.Game.treeLevel].SetActive(true);
            popupImage[1 - Managers.Game.treeLevel].SetActive(false);
        }

        popupAnimator.SetTrigger("doShow");
        //treeUpgrade();
    }

    public void treeUpgrade()
    {

        //���� �����ϸ� ����
        if (Managers.Game.coin < Managers.Game.treePrices[Managers.Game.treeLevel]) return;

        //��ȭ ���
        //Managers.Game.coin -= Managers.Game.treePrices[Managers.Game.treeLevel];
        shopUISystem.SetCoin(-Managers.Game.treePrices[Managers.Game.treeLevel]);
        //���� ��
        Managers.Game.treeLevel += 1;

        Debug.Log("coin " + Managers.Game.coin);
        ClosePopup();

    }

    public void ClosePopup()
    {
        popupAnimator.SetTrigger("doHide");
    }

    public void Reset()
    {
        Managers.Game.treeLevel = 0;
    }

    public void Init()
    {
        
    }
}
