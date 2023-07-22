using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TreeHpController : MonoBehaviour
{
    Slider hpSlider;
    TreeController tree;
    GameObject fillArea;
    float speed = 3f;
    void Start()
    {
        hpSlider = GetComponent<Slider>();
        tree = GameObject.Find("Tree").GetComponent<TreeController>();
        fillArea = GameObject.Find("Fill Area");
    }

    // Update is called once per frame
    void Update()
    {
        hpSlider.value = Mathf.Lerp(hpSlider.value, tree.Stat.Hp / tree.maxHp, Time.deltaTime * speed) ;
        if (hpSlider.value <= 0f)
        {
            fillArea.SetActive(false);
        }
    }
}
