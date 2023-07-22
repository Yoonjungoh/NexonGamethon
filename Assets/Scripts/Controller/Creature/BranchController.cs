using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchController : MonoBehaviour
{
    public Define.BranchType type;
    void Start()
    {
        Managers.Game.InGameBranches.Add(this);
        if (gameObject.name == "L1Branch")
            type = Define.BranchType.L1;
        else if (gameObject.name == "L2Branch")
            type = Define.BranchType.L2;
        else if (gameObject.name == "R1Branch")
            type = Define.BranchType.R1;
        else if (gameObject.name == "R2Branch")
            type = Define.BranchType.R2;
        else
            type = Define.BranchType.None;

        for (int i = 0; i < Managers.Game.branchL.Length; i++)
        {
            if (i == 0 && Managers.Game.branchL[i] == false && this.type == Define.BranchType.L1)
                gameObject.SetActive(false);
            else if (i == 1 && Managers.Game.branchL[i] == false && this.type == Define.BranchType.L2)
                gameObject.SetActive(false);
        }
        for (int i = 0; i < Managers.Game.branchR.Length; i++)
        {
            if (i == 0 && Managers.Game.branchR[i] == false && this.type == Define.BranchType.R1)
                gameObject.SetActive(false);
            else if (i == 1 && Managers.Game.branchR[i] == false && this.type == Define.BranchType.R2)
                gameObject.SetActive(false);
        }
    }

    void Update()
    {

    }
}
