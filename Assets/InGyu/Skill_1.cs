using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_1 : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) //���� A�� ������
        {
            transform.eulerAngles = new Vector3(0, -180, 0); //���� �ٶ󺸱�
        }
        if (Input.GetKeyDown(KeyCode.D)) //���� D�� ������
        {
            transform.eulerAngles = new Vector3(0, 0, 0); //������ �ٶ󺸱�
        }
        if (Input.GetKeyDown(KeyCode.S)) //���� S�� ������
        {
            Instantiate(bullet, bulletPos.transform.position, transform.rotation); //�Ѿ� ����
        }
    }
}