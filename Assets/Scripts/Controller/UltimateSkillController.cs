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
                for (int i = 0; i < Managers.Game.monsters.Count; i++)
                {
                    float damage = 50 + (Managers.Game.UltimateSkillLevel * 50);
                    Managers.Game.monsters[i].OnDamaged(damage);
                }
            }
        }
    }
}
