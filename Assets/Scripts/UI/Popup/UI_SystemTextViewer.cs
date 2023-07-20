using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_SystemTextViewer : MonoBehaviour
{
    private TextMeshProUGUI textSystem;
    private TMPAlpha tmpAlpha;

   void Start()
    {

    }

    public void PrintSystemText()
    {
        textSystem.text = $"원하는 내용 쓰기";
        tmpAlpha.FadeOut();
    }
}
