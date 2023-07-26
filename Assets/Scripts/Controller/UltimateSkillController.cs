using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltimateSkillController : MonoBehaviour
{
    void UseUltimateSkill()
    {
        if (Managers.Game.CanUseUltimateSkill == true)
        {
            Managers.Game.CanUseUltimateSkill = false;
            GameObject[] monsters = GameObject.FindGameObjectsWithTag("Monster");
            if (monsters.Length != 0)
            {
                for (int i = 0; i < monsters.Length; i++)
                {
                    MonsterController monster = monsters[i].GetComponent<MonsterController>();
                    float damage = 50 + (Managers.Game.UltimateSkillLevel * 50);
                    monster.OnDamaged(damage);
                }
            }
        }
    }
}
