using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoad : MonoBehaviour
{


    public void GameStart()
    {
        PlayerPrefs.SetInt("isSave", 0);
        Managers.Scene.LoadScene("OutGame");
    }


    public void GameExit()
    {
        PlayerPrefs.SetInt("isSave", 0);
        Application.Quit();
    }
}
