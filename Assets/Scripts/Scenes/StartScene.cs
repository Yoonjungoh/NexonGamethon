using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScene : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(CoGoToGameScene());
    }
    public IEnumerator CoGoToGameScene()
    {
        yield return new WaitForSeconds(2f);
        Managers.Scene.LoadScene("Game");
    }
}
