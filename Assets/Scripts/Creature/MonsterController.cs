using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : CreatureController
{
    GameObject _target;
    void Start()
    {
        _target = GameObject.Find("Tree");
    }
    void Update()
    {
        FollowTree();
    }
    void FollowTree()
    {

    }
    private void OnDrawGizmos()
    {

    }
}
