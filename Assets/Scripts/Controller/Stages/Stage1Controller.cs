using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1Controller : MonoBehaviour
{
    public float Timer = 0f;
    bool[] waves = new bool[4];
    MonsterSpawnerController msc;
    void Start()
    {
        msc = GetComponent<MonsterSpawnerController>();
    }

    void Update()
    {
        Timer += Time.deltaTime;
        if (Timer >= 2f && waves[0] == false)
        {
            waves[0] = true;
            msc.SpawnMonster("CommonMonster", 15, 3f);
        }
        if (Timer >= 11.3f && waves[1] == false)
        {
            waves[1] = true;
        }
        if (Timer >= 20f && waves[2] == false)
        {
            waves[2] = true;
        }
        if (Timer >= 26.3f && waves[3] == false)
        {
            waves[3] = true;
        }
    }
}
