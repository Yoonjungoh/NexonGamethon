using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_EndPopup : UI_Popup
{
    enum Buttons
    {
        EndButton,
    }
    void Start()
    {
        Managers.Game.Gaming = false;
        Bind<Button>(typeof(Buttons));

        GetButton((int)Buttons.EndButton).onClick.AddListener(Exit);
        Managers.Game.InGameBranches.Clear();
        Managers.Game.monsters.Clear();
        Managers.Game.Crystal = Managers.Game.CrystalDefaultValue;
        Time.timeScale = 0;
    }

    void Exit()
    {
        Application.Quit();
    }
}
