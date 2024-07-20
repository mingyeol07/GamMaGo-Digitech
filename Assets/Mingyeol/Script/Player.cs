using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rigid;
    [SerializeField] private float speed;
    [SerializeField] private float jumpSpeed;
    private Vector2 boxCheckOffset = new Vector2(0, -0.625f);
    private Vector2 boxCheckSize = new Vector2(0.6f, 0.1f);

    private int jumpCount = 2;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        GroundCheck();
        RotationY();
        Move();
        Jump();
    }

    private void RotationY()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    private void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");

        rigid.velocity = new Vector2(h * speed, rigid.velocity.y);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount > 0)
        {
            jumpCount--;
            rigid.velocity = new Vector2(rigid.velocity.x, jumpSpeed);
        }
    }

    private void GroundCheck()
    {
        Vector2 position = (Vector2)transform.position + boxCheckOffset;
        bool isGround = Physics2D.OverlapBox(position, boxCheckSize, 0, LayerMask.GetMask("Ground"));

        if (isGround && jumpCount == 0)
        {
            jumpCount = 2;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector2 position = (Vector2)transform.position + boxCheckOffset;
        Gizmos.DrawWireCube(position, boxCheckSize);
    }
}
