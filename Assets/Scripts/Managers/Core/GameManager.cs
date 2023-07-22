using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    public int Id = 100;
    public int Crystal = 100;
    public bool LoadCompleted = false;
    public List<BranchController> InGameBranches = new List<BranchController>();
    public List<MonsterController> monsters = new List<MonsterController>();
    public int CurrentStage = 1;
    public SpawnPoint[] SpawnPoints;
    // 터렛 강화 정보
    public int SquirrelTurretLevel = 1;
    public int OwlTurretLevel = 1;
    public int DeerTurretLevel = 1;
    public int BearTurretLevel = 1;
    public float[] SquirrelCost;
    public float[] OwlCost;
    public float[] DeerCost;
    public float[] BearCost;
}
