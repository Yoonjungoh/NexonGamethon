using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1Controller : MonoBehaviour
{
    public float Timer = 0f;
    bool[] waves1 = new bool[4];
    bool[] waves2 = new bool[6];
    bool[] waves3 = new bool[8];
    bool[] waves4 = new bool[8];
    bool[] waves5 = new bool[9];
    MonsterSpawnerController msc;
    float crystalTimer = 0f;
    void Start()
    {
        msc = GetComponent<MonsterSpawnerController>();
    }
    void Stage1()
    {
        Timer += Time.deltaTime;
        crystalTimer += Time.deltaTime;
        if (crystalTimer >= 1f)
        {
            Managers.Game.Crystal += 1;
            crystalTimer = 0f;
        }
        if (Timer >= 2f && waves1[0] == false)
        {
            waves1[0] = true;
            //msc.SpawnMonster("BombMonster", 15, 3f, Define.MoveDir.Left);
            msc.SpawnMonster(Define.MonsterType.Common, 15, 3f, Define.MoveDir.Left);
        }
        if (Timer >= 11.3f && waves1[1] == false)
        {
            waves1[1] = true;
            msc.SpawnMonster("FireMonster", 12, 3f, Define.MoveDir.Left);
        }
        if (Timer >= 20f && waves1[2] == false)
        {
            waves1[2] = true;
            msc.SpawnMonster("CommonMonster", 8, 3f, Define.MoveDir.Right);
        }
        if (Timer >= 26.3f && waves1[3] == false)
        {
            waves1[3] = true;
            msc.SpawnMonster("CommonMonster", 6, 3f, Define.MoveDir.Right);
        }
    }
    void Stage2()
    {
        Timer += Time.deltaTime;
        crystalTimer += Time.deltaTime;
        if (crystalTimer >= 1f)
        {
            Managers.Game.Crystal += 1;
            crystalTimer = 0f;
        }
        if (Timer >= 1f && waves2[0] == false)
        {
            waves2[0] = true;
            msc.SpawnMonster("TankMonster", 12, 4f, Define.MoveDir.Left);
        }
        if (Timer >= 7f && waves2[1] == false)
        {
            waves2[1] = true;
            msc.SpawnMonster("CommonMonster", 18, 3f, Define.MoveDir.Left);
        }
        if (Timer >= 8f && waves2[2] == false)
        {
            waves2[2] = true;
            msc.SpawnMonster("FireMonster", 18, 3f, Define.MoveDir.Left);
        }
        if (Timer >= 18f && waves2[3] == false)
        {
            waves2[3] = true;
            msc.SpawnMonster("TankMonster", 6, 4f, Define.MoveDir.Right);
        }
        if (Timer >= 24f && waves2[4] == false)
        {
            waves2[4] = true;
            msc.SpawnMonster("CommonMonster", 12, 3f, Define.MoveDir.Right);
        }
        if (Timer >= 25f && waves2[5] == false)
        {
            waves2[5] = true;
            msc.SpawnMonster("FireMonster", 12, 3f, Define.MoveDir.Right);
        }
    }
    void Stage3()
    {
        Timer += Time.deltaTime;
        crystalTimer += Time.deltaTime;
        if (crystalTimer >= 1f)
        {
            Managers.Game.Crystal += 1;
            crystalTimer = 0f;
        }
        if (Timer >= 1f && waves2[0] == false)
        {
            waves2[0] = true;
            msc.SpawnMonster("TankMonster", 12, 4f, Define.MoveDir.Left);
        }
        if (Timer >= 7f && waves2[1] == false)
        {
            waves2[1] = true;
            msc.SpawnMonster("CommonMonster", 18, 3f, Define.MoveDir.Left);
        }
        if (Timer >= 8f && waves2[2] == false)
        {
            waves2[2] = true;
            msc.SpawnMonster("FireMonster", 18, 3f, Define.MoveDir.Left);
        }
        if (Timer >= 18f && waves2[3] == false)
        {
            waves2[3] = true;
            msc.SpawnMonster("TankMonster", 6, 4f, Define.MoveDir.Right);
        }
        if (Timer >= 24f && waves2[4] == false)
        {
            waves2[4] = true;
            msc.SpawnMonster("CommonMonster", 12, 3f, Define.MoveDir.Right);
        }
        if (Timer >= 25f && waves2[5] == false)
        {
            waves2[5] = true;
            msc.SpawnMonster("FireMonster", 12, 3f, Define.MoveDir.Right);
        }
    }
    //void Stage4()
    //{
    //    Timer += Time.deltaTime;
    //    crystalTimer += Time.deltaTime;
    //    if (crystalTimer >= 1f)
    //    {
    //        Managers.Game.Crystal += 1;
    //        crystalTimer = 0f;
    //    }
    //    if (Timer >= 2f && waves[0] == false)
    //    {
    //        waves[0] = true;
    //        //msc.SpawnMonster("BombMonster", 15, 3f, Define.MoveDir.Left);
    //        msc.SpawnMonster("CommonMonster", 15, 3f, Define.MoveDir.Left);
    //    }
    //    if (Timer >= 11.3f && waves[1] == false)
    //    {
    //        waves[1] = true;
    //        msc.SpawnMonster("FireMonster", 12, 3f, Define.MoveDir.Left);
    //    }
    //    if (Timer >= 20f && waves[2] == false)
    //    {
    //        waves[2] = true;
    //        msc.SpawnMonster("CommonMonster", 8, 3f, Define.MoveDir.Right);
    //    }
    //    if (Timer >= 26.3f && waves[3] == false)
    //    {
    //        waves[3] = true;
    //        msc.SpawnMonster("CommonMonster", 6, 3f, Define.MoveDir.Right);
    //    }
    //}
    //void Stage5()
    //{
    //    Timer += Time.deltaTime;
    //    crystalTimer += Time.deltaTime;
    //    if (crystalTimer >= 1f)
    //    {
    //        Managers.Game.Crystal += 1;
    //        crystalTimer = 0f;
    //    }
    //    if (Timer >= 2f && waves[0] == false)
    //    {
    //        waves[0] = true;
    //        //msc.SpawnMonster("BombMonster", 15, 3f, Define.MoveDir.Left);
    //        msc.SpawnMonster("CommonMonster", 15, 3f, Define.MoveDir.Left);
    //    }
    //    if (Timer >= 11.3f && waves[1] == false)
    //    {
    //        waves[1] = true;
    //        msc.SpawnMonster("FireMonster", 12, 3f, Define.MoveDir.Left);
    //    }
    //    if (Timer >= 20f && waves[2] == false)
    //    {
    //        waves[2] = true;
    //        msc.SpawnMonster("CommonMonster", 8, 3f, Define.MoveDir.Right);
    //    }
    //    if (Timer >= 26.3f && waves[3] == false)
    //    {
    //        waves[3] = true;
    //        msc.SpawnMonster("CommonMonster", 6, 3f, Define.MoveDir.Right);
    //    }
    //}

    void Update()
    {
        switch (Managers.Game.CurrentStage)
        {
            case 1:
                Stage1();
                break;
            case 2:
                Stage2();
                break;
            case 3:
                Stage3();
                break;
            case 4:
                //Stage4();
                break;
            case 5:
                //Stage5();
                break;
        }
    }
}
