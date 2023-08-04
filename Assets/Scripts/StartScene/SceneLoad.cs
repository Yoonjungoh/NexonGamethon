using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoad : MonoBehaviour
{


    public void GameStart()
    {
        Managers.Sound.Play("Effect/ButtonClickSound");
        PlayerPrefs.SetInt("isSave", 0);
        Managers.Scene.LoadScene("OutGame");
    }


    public void GameExit()
    {
        Managers.Sound.Play("Effect/ButtonClickSound");
        PlayerPrefs.SetInt("isSave", 0);
        Application.Quit();
    }
}
