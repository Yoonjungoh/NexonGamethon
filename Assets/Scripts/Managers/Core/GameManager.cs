using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    public bool Gaming = false;
    public int CrystalDefaultValue = 10;
    public int Crystal = 10;
    public bool LoadCompleted = false;
    public List<BranchController> InGameBranches = new List<BranchController>();
    public List<MonsterController> monsters = new List<MonsterController>();
    public int CurrentStage = 1;
    public SpawnPoint[] SpawnPoints;

    // �ͷ� �ڽ�Ʈ ����
    public float SquirrelCost = 10;
    public float OwlCost = 20;
    public float DeerCost = 25;
    public float BearCost = 40;


    // �ʻ�� ��ȭ ����
    public int UltimateSkillLevel = 1;
    public int coin = 150;

    // Outgame
    [Header("Turret")]
    public int[] turret_Lv = { 1, 0, 0, 0 };
    public int[,] turretPrices = new int[4, 3] { { 100, 140, 200 }, { 150, 210, 300 }, { 200, 280, 400 }, { 300, 420, 600 } };
    public int stageLevel = 4; //���������� �ѹ� (�ͷ��ذ��� ���)
    public int paidCoin = 0;


    [Header("Tree")]
    // ���� ��ȭ ����
    public int treeLevel = 0;
    public int[] treePrices = { 300, 500 };

    [Header("Branch")]
    public bool[] branchL = { false, false };
    public bool[] branchR = { false, false };
    public int[] branchLPrice = { 150, 200 };
    public int[] branchRPrice = { 150, 200 };

    public int KillCount = 0;

    public int[] WaveCounts;
    public int Wave1Count = 35;
    public int Wave2Count = 75;
    public int Wave3Count = 61;
    public int Wave4Count = 40;
    public int Wave5Count = 30;
    public bool CanUseUltimateSkill = true;
    public void ClearStage()
    {
        Managers.UI.ShowPopupUI<UI_ClearPopup>();
        Debug.Log($"��������{Managers.Game.CurrentStage} Ŭ����!");
        GetCoin();
        Managers.Game.CurrentStage++;
    }
    void GetCoin()
    {
        float result = 0;
        if (Managers.Game.CurrentStage == 1)
            result = 300;
        if (Managers.Game.CurrentStage == 2)
            result = 500;
        if (Managers.Game.CurrentStage == 3)
            result = 700;
        if (Managers.Game.CurrentStage == 4)
            result = 1000;
        Managers.Game.coin += (int)result;
    }
}
