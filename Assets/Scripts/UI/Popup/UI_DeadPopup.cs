using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_DeadPopup : UI_Popup
{
    enum Buttons
    {
        DeadButton,
    }
    void Start()
    {
        Time.timeScale = 0;
        Managers.Game.Gaming = false;
        Bind<Button>(typeof(Buttons));

        GetButton((int)Buttons.DeadButton).onClick.AddListener(GoToShopScene);
        foreach (MonsterController monster in Managers.Game.monsters)
            monster.State = Define.CreatureState.Idle;
        Managers.Game.InGameBranches.Clear();
        Managers.Game.monsters.Clear();
        Managers.Game.Crystal = Managers.Game.CrystalDefaultValue;
    }

    void GoToShopScene()
    {
        Managers.Sound.Play("Effect/ButtonClickSound");
        Managers.Game.CanUseUltimateSkill = true;
        Managers.Scene.LoadScene("OutGame");
        gameObject.SetActive(true);
    }
}
