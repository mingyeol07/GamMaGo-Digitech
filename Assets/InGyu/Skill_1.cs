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
        if (Input.GetKeyDown(KeyCode.A)) //만약 A를 누르면
        {
            transform.eulerAngles = new Vector3(0, -180, 0); //왼쪽 바라보기
        }
        if (Input.GetKeyDown(KeyCode.D)) //만약 D를 누르면
        {
            transform.eulerAngles = new Vector3(0, 0, 0); //오른쪽 바라보기
        }
        if (Input.GetKeyDown(KeyCode.S)) //만약 S를 누르면
        {
            Instantiate(bullet, bulletPos.transform.position, transform.rotation); //총알 생성
        }
    }
}