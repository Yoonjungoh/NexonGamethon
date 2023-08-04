using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_ClearPopup : UI_Popup
{
    enum Buttons
    {
        ClearButton,
    }
    void Start()
    {
        Managers.Game.Gaming = false;
        Bind<Button>(typeof(Buttons));

        GetButton((int)Buttons.ClearButton).onClick.AddListener(GoToShopScene);
        Managers.Game.InGameBranches.Clear();
        Managers.Game.monsters.Clear();
        Managers.Game.Crystal = Managers.Game.CrystalDefaultValue;
    }

    void GoToShopScene()
    {
        Managers.Sound.Play("Effect/ButtonClickSound");
        Time.timeScale = 1;
        Managers.Game.CanUseUltimateSkill = true;
        Managers.Scene.LoadScene("OutGame");
        gameObject.SetActive(true);
    }
}
