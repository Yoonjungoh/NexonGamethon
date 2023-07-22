using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Crystal : UI_Scene
{
    TextMeshProUGUI crystalText;
    enum Texts
    {
        CrystalText,
    }
    void Start()
    {
        Bind<TextMeshProUGUI>(typeof(Texts));
        crystalText = GetTextMeshProUGUI((int)(Texts.CrystalText));
    }
    void Update()
    {
        crystalText.text = $"Å©¸®½ºÅ»: {Managers.Game.Crystal}";
    }
}
