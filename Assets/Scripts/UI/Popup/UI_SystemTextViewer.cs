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
        textSystem.text = $"���ϴ� ���� ����";
        tmpAlpha.FadeOut();
    }
}
