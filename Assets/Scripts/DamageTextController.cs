using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamageTextController : MonoBehaviour
{
    TextMeshPro text;
    Color _color;
    public float damage;
    // 텍스트 이동 속도
    private float _moveSpeed = 2f;
    // 투명도 변환 속도
    private float _alphaSpeed = 2f;
    // 데미지 뷰어 오브젝트 Hide 시간
    private float _hidingTime = 2f;
    void Start()
    {
        GameObject damageViewerFolder = GameObject.Find("DamageViewers");
        if (damageViewerFolder == null)
            damageViewerFolder = new GameObject { name = "DamageViewers" };

        text = GetComponent<TextMeshPro>();
        text.text = damage.ToString();
        _color = text.color;
        Invoke("HideDamageViewer", _hidingTime);

        // 데미지 뷰어 부모 설정
        transform.parent = damageViewerFolder.transform;
    }

    void Update()
    {
        transform.Translate(new Vector3(0, _moveSpeed * Time.deltaTime, 0));
        _color.a = Mathf.Lerp(_color.a, 0, Time.deltaTime * _alphaSpeed);
        text.color = _color;
    }
    // 오브젝트 풀링을 위한 데미지 뷰어 숨기기
    void HideDamageViewer()
    {
        gameObject.SetActive(false);
    }
}
