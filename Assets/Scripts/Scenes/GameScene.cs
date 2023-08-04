using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Managers.Sound.Play("Bgm/GameScene", Define.Sound.Bgm);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
