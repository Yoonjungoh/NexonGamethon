using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class turretLevel : MonoBehaviour
{
    public Image fillImage;

    void Start()
    {
        // 시작할 때 fillAmount 초기화
        fillImage.fillAmount = 0.0f;
    }

    // fillAmount를 특정 값으로 설정하는 함수
    public void SetFillAmount(int level )
    {
        Debug.Log("setfillamount "+level);
        if(level == 0)
        {
            fillImage.fillAmount = Mathf.Clamp01(0);
        }
        else if(level == 1)
        {
            fillImage.fillAmount = Mathf.Clamp01(0.35f);
        }
        else if (level == 2)
        {
            fillImage.fillAmount = Mathf.Clamp01(0.7f);
        }
        else if (level == 3)
        {
            fillImage.fillAmount = Mathf.Clamp01(1);
        }

    }

}
//0, 0.35, 0.7, 1