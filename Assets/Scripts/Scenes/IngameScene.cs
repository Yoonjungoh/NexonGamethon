using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Managers.Sound.Play("BGM/BattleStageBGM", Define.Sound.Bgm);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
