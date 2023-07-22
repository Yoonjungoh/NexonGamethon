using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScene : MonoBehaviour
{
    public float time = 3f;
    void Start()
    {
        Managers.Resource.Instantiate("TreeHpSlider");
        StartCoroutine(CoGoToGameScene());
    }
    public IEnumerator CoGoToGameScene()
    {
        yield return new WaitForSeconds(time);
        Managers.Scene.LoadScene("Stage1");
    }
}
