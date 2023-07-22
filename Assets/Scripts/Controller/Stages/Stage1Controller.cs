using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1Controller : MonoBehaviour
{
    public float Timer = 0f;
    bool[] waves = new bool[4];
    MonsterSpawnerController msc;
    float crystalTimer = 0f;
    void Start()
    {
        msc = GetComponent<MonsterSpawnerController>();
    }

    void Update()
    {
        Timer += Time.deltaTime;
        crystalTimer += Time.deltaTime;
        if (crystalTimer >= 1f)
        {
            Managers.Game.Crystal += 2;
            crystalTimer = 0f;
        }
        if (Timer >= 2f && waves[0] == false)
        {
            waves[0] = true;
            msc.SpawnMonster("CommonMonster", 15, 3f, Define.MoveDir.Left);
        }
        if (Timer >= 11.3f && waves[1] == false)
        {
            waves[1] = true;
            msc.SpawnMonster("FireMonster", 12, 3f, Define.MoveDir.Left);
        }
        if (Timer >= 20f && waves[2] == false)
        {
            waves[2] = true;
            msc.SpawnMonster("CommonMonster", 8, 3f, Define.MoveDir.Right);
        }
        if (Timer >= 26.3f && waves[3] == false)
        {
            waves[3] = true;
            msc.SpawnMonster("CommonMonster", 6, 3f, Define.MoveDir.Right);
        }
    }
}
