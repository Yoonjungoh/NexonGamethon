using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    public int Id = 100;
    public int coin;
    public bool LoadCompleted = false;
    public List<BranchController> InGameBranches = new List<BranchController>();
    public List<MonsterController> monsters = new List<MonsterController>();
    public int CurrentStage = 1;
    public SpawnPoint[] SpawnPoints;
}
