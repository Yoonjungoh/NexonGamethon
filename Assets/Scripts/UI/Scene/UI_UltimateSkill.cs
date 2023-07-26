using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_UltimateSkill : UI_Scene
{
    Animator animator;
    enum Buttons
    {
        UltimateSkillButton,
    }
    void Start()
    {
        Bind<Button>(typeof(Buttons));
        GetButton((int)Buttons.UltimateSkillButton).onClick.AddListener(ClickUseUltimateSkill);
        animator = GetComponent<Animator>();
    }

    void ClickUseUltimateSkill()
    {
        GameObject.Find("UltimateSkill").GetComponent<Animator>().Play("ULTIMATE_SKILL");
    }
    void UseUltimateSkill()
    {
        if (Managers.Game.CanUseUltimateSkill == true)
        {
            Managers.Game.CanUseUltimateSkill = false;
            foreach (MonsterController monster in Managers.Game.monsters)
            {
                float damage = 50 + (Managers.Game.UltimateSkillLevel * 50);
                monster.OnDamaged(damage);
            }
        }
    }
}
