using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TreeHpController : MonoBehaviour
{
    Slider hpSlider;
    TreeController tree;
    void Start()
    {
        hpSlider = GetComponent<Slider>();
        tree = GameObject.Find("Tree").GetComponent<TreeController>();
    }

    // Update is called once per frame
    void Update()
    {
        hpSlider.value = tree.Stat.Hp / tree.maxHp;
    }
}
