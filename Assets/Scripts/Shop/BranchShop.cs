using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BranchShop : MonoBehaviour
{
    public GameObject popup_L;
    public GameObject popup_R;
    public GameObject[] branchLock_L;
    public GameObject[] branchLock_R;
    private Animator popupAnimator_L;
    private Animator popupAnimator_R;
    private int branchLNum=0;
    private int branchRNum=0;
    public ShopUISystem shopUISystem;
    public GameObject[] popupImagesL;
    public GameObject[] popupImagesR;


    // Start is called before the first frame update
    void Start()
    {
        popupAnimator_R = popup_R.GetComponent<Animator>();
        popupAnimator_L = popup_L.GetComponent<Animator>();
    }

    private void Awake()
    {
        for (int i = 0; i < 2; i++)
        {
            branchLock_L[i].SetActive(!Managers.Game.branchL[i]);
            branchLock_R[i].SetActive(!Managers.Game.branchR[i]);
        }

    }

    public void ShowPopup_L(int idx)
    {
        
        //popupTxt_L.text= "������ " + Managers.Game.branchLPrice[idx] + "�Դϴ�";
        //���� ���������� ����
        if (Managers.Game.branchL[idx]) return;
        //���� ���� ������ �� ������ ����
        if (idx == 1 && !Managers.Game.branchL[idx - 1]) return;

        if(idx == 0)
        {
            popupImagesL[idx].SetActive(true);
            popupImagesL[1-idx].SetActive(false);
        }
        else
        {
            popupImagesL[idx].SetActive(true);
            popupImagesL[1 - idx].SetActive(false);
        }

        popupAnimator_L.SetTrigger("doShow");
        branchLNum = idx;
    }
    public void ShowPopup_R(int idx)
    {
        //���� ���������� ����
        if (Managers.Game.branchR[idx]) return;
        //���� ���� ������ �� ������ ����
        if (idx == 1 && !Managers.Game.branchR[idx - 1]) return;

        if (idx == 0)
        {
            popupImagesR[idx].SetActive(true);
            popupImagesR[1 - idx].SetActive(false);
        }
        else
        {
            popupImagesR[idx].SetActive(true);
            popupImagesR[1 - idx].SetActive(false);
        }

        popupAnimator_R.SetTrigger("doShow");
        branchRNum = idx;
    }

    public void ClosePopup_L()
    {
        popupAnimator_L.SetTrigger("doHide");
    }
    public void ClosePopup_R()
    {
        popupAnimator_R.SetTrigger("doHide");
    }

    public void buyBranch_L()
    {
        //���� ���� ����
        if (Managers.Game.coin < Managers.Game.branchLPrice[branchLNum]) return;

        //��ȭ ���
        //Managers.Game.coin -= Managers.Game.branchLPrice[branchLNum];
        shopUISystem.SetCoin(-Managers.Game.branchLPrice[branchLNum]);

        //���� ó��
        Managers.Game.branchL[branchLNum] = true;

        Debug.Log(Managers.Game.coin);

        //�ذ�
        branchLock_L[branchLNum].SetActive(false);

        //�˾� ����
        popupAnimator_L.SetTrigger("doHide");
    }
    public void buyBranch_R()
    {
        //���� ���� ����
        if (Managers.Game.coin < Managers.Game.branchRPrice[branchRNum]) return;

        //��ȭ ���
        //Managers.Game.coin -= Managers.Game.branchRPrice[branchRNum];
        shopUISystem.SetCoin(-Managers.Game.branchRPrice[branchRNum]);

        //���� ó��
        Managers.Game.branchR[branchRNum] = true;

        Debug.Log(Managers.Game.coin);

        //�ذ�
        branchLock_R[branchRNum].SetActive(false);

        //�˾� ����
        popupAnimator_R.SetTrigger("doHide");
    }

    public void Reset()
    {
        branchLNum = 0;
        branchRNum = 0;

        for(int i = 0; i < 2; i++)
        {
            Managers.Game.branchL[i] = false;
            Managers.Game.branchR[i] = false;

            branchLock_L[i].SetActive(true);
            branchLock_R[i].SetActive(true);
        }
    }
}
