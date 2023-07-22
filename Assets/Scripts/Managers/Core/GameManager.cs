using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    public int Crystal = 100;
    public bool LoadCompleted = false;
    public List<BranchController> InGameBranches = new List<BranchController>();
    public List<MonsterController> monsters = new List<MonsterController>();
    public int CurrentStage = 1;
    public SpawnPoint[] SpawnPoints;

    // �ͷ� ��ȭ ����
    public float[] SquirrelCost;
    public float[] OwlCost;
    public float[] DeerCost;
    public float[] BearCost;


    // �ʻ�� ��ȭ ����
    public int UltimateSkillLevel = 1;
    public int coin = 10000;

    // Outgame
    [Header("Turret")]
    //public int[] turret_Lv = { 1, 0, 0, 0 };
    public int[] turret_Lv = { 1, 1, 1, 1 };
    public int[,] turretPrices = new int[4, 3] { { 10, 100, 140 }, { 20, 150, 210 }, { 25, 200, 280 }, { 40, 300, 420 } };
    public int stageLevel = 4; //���������� �ѹ� (�ͷ��ذ��� ���)
    public int paidCoin = 0;

    [Header("Tree")]
    // ���� ��ȭ ����
    public int treeLevel = 0;
    public int[] treePrices = { 10, 20 };

    [Header("Branch")]
    public bool[] branchL = { false, false };
    public bool[] branchR = { false, false };
    public int[] branchLPrice = { 100, 200 };
    public int[] branchRPrice = { 100, 200 };

}
