using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScene : MonoBehaviour
{
    void Start()
    {
        Managers.Sound.Play("Bgm/MainScene", Define.Sound.Bgm);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
