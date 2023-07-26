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
            if (Managers.Game.monsters.Count != 0)
            {
                foreach (MonsterController monster in Managers.Game.monsters)
                {
                    float damage = 50 + (Managers.Game.UltimateSkillLevel * 50);
                    monster.OnDamaged(damage);
                }
            }
        }
    }
}
