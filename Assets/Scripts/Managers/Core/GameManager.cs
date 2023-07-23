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

    // 터렛 강화 정보
    public float[] SquirrelCost;
    public float[] OwlCost;
    public float[] DeerCost;
    public float[] BearCost;


    // 필살기 강화 정보
    public int UltimateSkillLevel = 1;
    public int coin = 150;

    // Outgame
    [Header("Turret")]
    public int[] turret_Lv = { 1, 0, 0, 0 };
    public int[,] turretPrices = new int[4, 3] { { 100, 140, 200 }, { 150, 210, 300 }, { 200, 280, 400 }, { 300, 420, 600 } };
    public int stageLevel = 4; //씬스테이지 넘버 (터렛해감에 사용)
    public int paidCoin = 0;


    [Header("Tree")]
    // 나무 강화 정보
    public int treeLevel = 0;
    public int[] treePrices = { 10, 20 };

    [Header("Branch")]
    public bool[] branchL = { false, false };
    public bool[] branchR = { false, false };
    public int[] branchLPrice = { 100, 200 };
    public int[] branchRPrice = { 100, 200 };

    public int KillCount = 0;

    public int[] WaveCounts;
    public int Wave1Count = 41;
    public int Wave2Count = 78;
    public int Wave3Count = 63;
    public int Wave4Count = 42;
    public int Wave5Count = 32;
    public bool CanUseUltimateSkill = true;
    public void ClearStage()
    {
        Managers.UI.ShowPopupUI<UI_ClearPopup>();
        Debug.Log($"스테이지{Managers.Game.CurrentStage} 클리어!");
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
