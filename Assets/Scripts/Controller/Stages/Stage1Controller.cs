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

    int perCrystal = 2;
    MonsterSpawnerController msc;
    float crystalTimer = 0f;
    void Start()
    {
        Managers.Game.Gaming = true;
        msc = GetComponent<MonsterSpawnerController>();
        Managers.Game.KillCount = 0;
    }
    void Stage1()
    {
        Timer += Time.deltaTime;
        crystalTimer += Time.deltaTime;
        if (crystalTimer >= 1f)
        {
            Managers.Game.Crystal += perCrystal;
            crystalTimer = 0f;
        }
        if (Timer >= 2f && waves1[0] == false)
        {
            waves1[0] = true;
            msc.SpawnMonster(Define.MonsterType.Common, 15, 3f, Define.MoveDir.Left);
            //msc.SpawnMonster("EliteMonster", Define.MoveDir.Left);
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
            Managers.Game.Crystal += perCrystal;
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
            Managers.Game.Crystal += perCrystal;
            crystalTimer = 0f;
        }
        if (Timer >= 1f && waves3[0] == false)
        {
            waves3[0] = true;
            msc.SpawnMonster(Define.MonsterType.Tank, 10, 4f, Define.MoveDir.Right);
        }
        if (Timer >= 3f && waves3[1] == false)
        {
            waves3[1] = true;
            msc.SpawnMonster(Define.MonsterType.Tank, 18, 3f, Define.MoveDir.Left);
        }
        if (Timer >= 10f && waves3[2] == false)
        {
            waves3[2] = true;
            msc.SpawnMonster(Define.MonsterType.Common, 5, 3f, Define.MoveDir.Left);
        }
        if (Timer >= 13f && waves3[3] == false)
        {
            waves3[3] = true;
            msc.SpawnMonster(Define.MonsterType.Common, 6, 3f, Define.MoveDir.Right);
        }
        if (Timer >= 14f && waves3[4] == false)
        {
            waves3[4] = true;
            msc.SpawnMonster(Define.MonsterType.Fast, 3, 2f, Define.MoveDir.Left);
        }
        if (Timer >= 18f && waves3[5] == false)
        {
            waves3[5] = true;
            msc.SpawnMonster(Define.MonsterType.Fast, 10, 2f, Define.MoveDir.Right);
        }
        if (Timer >= 21f && waves3[6] == false)
        {
            waves3[6] = true;
            msc.SpawnMonster(Define.MonsterType.Fire, 7, 3f, Define.MoveDir.Left);
        }
        if (Timer >= 28f && waves3[7] == false)
        {
            waves3[7] = true;
            msc.SpawnMonster(Define.MonsterType.Fire, 3, 3f, Define.MoveDir.Right);
        }
    }
    void Stage4()
    {
        Timer += Time.deltaTime;
        crystalTimer += Time.deltaTime;
        if (crystalTimer >= 1f)
        {
            Managers.Game.Crystal += perCrystal;
            crystalTimer = 0f;
        }
        if (Timer >= 1f && waves4[0] == false)
        {
            waves4[0] = true;
            msc.SpawnMonster(Define.MonsterType.Fast, 6, 2f, Define.MoveDir.Left);
        }
        if (Timer >= 8f && waves4[1] == false)
        {
            waves4[1] = true;
            msc.SpawnMonster(Define.MonsterType.Fast, 6, 2f, Define.MoveDir.Right);
        }
        if (Timer >= 11f && waves4[2] == false)
        {
            waves4[2] = true;
            msc.SpawnMonster(Define.MonsterType.Tank, 10, 4f, Define.MoveDir.Left);
        }
        if (Timer >= 12f && waves4[3] == false)
        {
            waves4[3] = true;
            msc.SpawnMonster(Define.MonsterType.Bomb, 2, 6f, Define.MoveDir.Left);
        }
        if (Timer >= 17f && waves4[4] == false)
        {
            waves4[4] = true;
            msc.SpawnMonster(Define.MonsterType.Tank, 5, 3f, Define.MoveDir.Right);
        }
        if (Timer >= 19f && waves4[5] == false)
        {
            waves4[5] = true;
            msc.SpawnMonster(Define.MonsterType.Bomb, 3, 5f, Define.MoveDir.Right);
        }
        if (Timer >= 21f && waves4[6] == false)
        {
            waves4[6] = true;
            msc.SpawnMonster(Define.MonsterType.Fire, 3, 3f, Define.MoveDir.Right);
        }
        if (Timer >= 27f && waves4[7] == false)
        {
            waves4[7] = true;
            msc.SpawnMonster(Define.MonsterType.Fire, 7, 3f, Define.MoveDir.Left);
        }
    }
    void Stage5()
    {
        Timer += Time.deltaTime;
        crystalTimer += Time.deltaTime;
        if (crystalTimer >= 1f)
        {
            Managers.Game.Crystal += perCrystal;
            crystalTimer = 0f;
        }
        if (Timer >= 1f && waves5[0] == false)
        {
            waves5[0] = true;
            msc.SpawnMonster(Define.MonsterType.Tank, 6, 1f, Define.MoveDir.Left);
        }
        if (Timer >= 5f && waves5[1] == false)
        {
            waves5[1] = true;
            msc.SpawnMonster("EliteMonster", Define.MoveDir.Left);
        }
        if (Timer >= 10f && waves5[2] == false)
        {
            waves5[2] = true;
            msc.SpawnMonster(Define.MonsterType.Fast, 10, 2f, Define.MoveDir.Left);
        }
        if (Timer >= 11f && waves5[3] == false)
        {
            waves5[3] = true;
            msc.SpawnMonster(Define.MonsterType.Tank, 2, 3f, Define.MoveDir.Right);
        }
        if (Timer >= 15f && waves5[4] == false)
        {
            waves5[4] = true;
            msc.SpawnMonster(Define.MonsterType.Fire, 5, 3f, Define.MoveDir.Left);
        }
        if (Timer >= 17f && waves5[5] == false)
        {
            waves5[5] = true;
            msc.SpawnMonster(Define.MonsterType.Fast, 3, 2f, Define.MoveDir.Right);
        }
        if (Timer >= 20f && waves5[6] == false)
        {
            waves5[6] = true;
            msc.SpawnMonster(Define.MonsterType.Bomb, 3, 6f, Define.MoveDir.Left);
        }
        if (Timer >= 21f && waves5[7] == false)
        {
            waves5[7] = true;
            msc.SpawnMonster(Define.MonsterType.Fire, 7, 3f, Define.MoveDir.Right);
        }
        if (Timer >= 30f && waves5[8] == false)
        {
            waves5[8] = true;
            msc.SpawnMonster(Define.MonsterType.Bomb, 7, 2f, Define.MoveDir.Right);
        }
    }

    void Update()
    {
        if (Managers.Game.Gaming)
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
                    Stage4();
                    break;
                case 5:
                    Stage5();
                    break;
            }
        }
    }
}
