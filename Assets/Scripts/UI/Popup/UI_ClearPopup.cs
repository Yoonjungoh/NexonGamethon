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
    enum Texts
    {
        ClearText,
    }
    void Start()
    {
        Bind<Button>(typeof(Buttons));
        Bind<TextMeshProUGUI>(typeof(Texts));

        GetButton((int)Buttons.ClearButton).onClick.AddListener(GoToShopScene);
        GetTextMeshProUGUI((int)Texts.ClearText).text = "Å¬¸®¾î~!";
    }

    void GoToShopScene()
    {
        Managers.Scene.LoadScene("OutGame");
    }
}
