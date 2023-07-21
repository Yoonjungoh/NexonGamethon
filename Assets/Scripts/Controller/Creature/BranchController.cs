using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchController : MonoBehaviour
{
    void Start()
    {
        Managers.Game.InGameBranches.Add(this);
        //gameObject.SetActive(false);
    }

    void Update()
    {

    }
}
