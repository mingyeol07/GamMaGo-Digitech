using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rigid;

    private int maxHp;
    private int curHp;
    private float[] speed = { 5, 5, 4, 3, 2 };
    [SerializeField] private float jumpSpeed;
    [SerializeField] private Transform player;

    private Vector2 boxCheckOffset = new Vector2(0, -0.625f);
    private Vector2 boxCheckSize = new Vector2(0.6f, 0.1f);

    private int jumpCount = 2;

    [SerializeField] private Animator sharpAnim;
    [SerializeField] private Animator boldAnim;
    private Collider2D[] colliders;
    [SerializeField] private Collider2D attackRange_Sharp;
    [SerializeField] private Collider2D attackRange_bold;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        curHp = maxHp;
    }

    private void Update()
    {
        GroundCheck();
        RotationY();
        ActingSkill();
        PickUpItemCheck();
        Move();
        Jump();
    }

    private void RotationY()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            player.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            player.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    private void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");

        rigid.velocity = new Vector2(h * speed[InventoryManager.Instance.level], rigid.velocity.y);
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

    public void SharpSlash()
    {
        attackRange_Sharp.enabled = true;
        sharpAnim.SetTrigger("Attack");
        StartCoroutine(OffColl());
    }

    public void BoldSlash()
    {
        attackRange_bold.enabled = true;
        boldAnim.SetTrigger("Attack");
        StartCoroutine(OffColl());
    }

    private IEnumerator OffColl()
    {
        yield return new WaitForSeconds(1f);

        attackRange_bold.enabled = false;
        attackRange_Sharp.enabled = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector2 position = (Vector2)transform.position + boxCheckOffset;
        Gizmos.DrawWireCube(position, boxCheckSize);
    }

    private void ActingSkill()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            InventoryManager.Instance.SkillActing(0);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            InventoryManager.Instance.SkillActing(1);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            InventoryManager.Instance.SkillActing(2);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            InventoryManager.Instance.SkillActing(3);
        }
    }

    private void HpDown()
    {
        InventoryManager.Instance.GetRandomItemSpawn();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Monster"))
        {
            HpDown();
        }

        if (collision.gameObject.CompareTag("Item"))
        {
            collision.gameObject.GetComponent<PickUpItem>().ItemPickUp();
            Destroy(collision.gameObject);
        }
    }

    private void PickUpItemCheck()
    {
        colliders = Physics2D.OverlapCircleAll(transform.position, 5, LayerMask.GetMask("Item"));

        for (int i = 0; i < colliders.Length; i++)
        {
            colliders[i].GetComponent<PickUpItem>().SetIsPickUp();
        }
    }
}
