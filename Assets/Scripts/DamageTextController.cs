using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamageTextController : MonoBehaviour
{
    TextMeshPro text;
    Color _color;
    public float damage;
    // �ؽ�Ʈ �̵� �ӵ�
    private float _moveSpeed = 2f;
    // ���� ��ȯ �ӵ�
    private float _alphaSpeed = 2f;
    // ������ ��� ������Ʈ Hide �ð�
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

        // ������ ��� �θ� ����
        transform.parent = damageViewerFolder.transform;
    }

    void Update()
    {
        transform.Translate(new Vector3(0, _moveSpeed * Time.deltaTime, 0));
        _color.a = Mathf.Lerp(_color.a, 0, Time.deltaTime * _alphaSpeed);
        text.color = _color;
    }
    // ������Ʈ Ǯ���� ���� ������ ��� �����
    void HideDamageViewer()
    {
        gameObject.SetActive(false);
    }
}
