using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{
    private Rigidbody2D rigid;

    public float Speed = 10f;

    private Vector2 movement = new Vector2();

    public float jumpPower;

    public bool isJump = false;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Start()
    {

    }


    private void Update()
    {
        Move();
        Jump();
    }



    void Move()
    {
        float h = Input.GetAxis("Horizontal");
        Vector3 pos = transform.position;
        pos.x += h * Speed * Time.deltaTime; //Time.deltaTime이란 컴퓨터 성능에 무관하게 여러 사용자의 동일한 FPS값을 보장해준다.
        transform.position = pos; //나의 위치를 pos값으로 초기화 시켜준다.
        if (Input.GetKeyDown(KeyCode.A))
        {
            rigid.AddForce(new Vector2(Speed, 0));
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isJump)
            {
                isJump = true;
                rigid.AddForce(Vector3.up * jumpPower, ForceMode2D.Impulse);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name.Equals("Ground"))
        {
            isJump = false;
        }
    }
}
