using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovoToTrashcan : MonoBehaviour
{
    //private GameObject m_goHpBar;
    private float m_fSpeed = 5.0f;
    public GameObject namePanel;

    void Start()
    {
        //m_goHpBar = GameObject.Find("Canvas/Slider");
    }

    void Update()
    {
        // ������Ʈ�� ���� �ǳ� ��ġ �̵�
        namePanel.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0, 2.2f, 0));
    }
}
