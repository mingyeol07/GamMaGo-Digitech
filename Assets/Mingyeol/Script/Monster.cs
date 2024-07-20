using System.Collections;
using UnityEngine;

public class Monster : MonoBehaviour
{
    private ColorType colorType;
    public ColorType _ColorType { get { return colorType; } }

    [SerializeField] private float speed;
    [SerializeField] private int maxHp = 10; // 기본 값 설정, 인스펙터에서 수정 가능

    private int curHp;

    private bool isDamaged;

    protected bool isAttack;
    protected bool isPlayerAttack;
    private bool isPlayerCheck;
    private Transform playerTransform;

    protected Rigidbody2D rigid;
    private LayerMask playerLayerMask;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        playerLayerMask = LayerMask.GetMask("Player");
    }

    private void Start()
    {
        curHp = maxHp;
        playerTransform = GameManager.Instance.Player.transform;

        StartCoroutine(Co_StartMove());
        StartCoroutine(Co_AttackLoop());
    }

    private void Update()
    {
        PlayerCheck();
    }

    private IEnumerator Co_StartMove()
    {
        while (!isPlayerCheck && !isDamaged)
        {
            int ranVec = Random.Range(-1, 2);

            if (ranVec < 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if (ranVec > 0)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }

            rigid.velocity = Vector2.right * ranVec * speed;
            yield return new WaitForSeconds(1f); // 이동 후 대기 시간 추가
        }
        rigid.velocity = Vector2.zero; // 플레이어를 발견하면 정지
    }

    private IEnumerator Co_AttackLoop()
    {
        while (true)
        {
            if (isPlayerAttack)
            {
                Attack();
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void PlayerCheck()
    {
        isPlayerCheck = Physics2D.OverlapCircle(transform.position, 6f, playerLayerMask);
        isPlayerAttack = Physics2D.OverlapCircle(transform.position, 3f, playerLayerMask);

        if (isPlayerCheck && !isPlayerAttack)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(playerTransform.position.x, transform.position.y), speed * Time.deltaTime);

            if (GameManager.Instance.Player.transform.position.x < transform.position.x)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if (GameManager.Instance.Player.transform.position.x > transform.position.x)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }

        }

    }

    protected virtual void Attack()
    {
        if (isPlayerAttack)
        {
            // 공격 로직 구현
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerAttack"))
        {
            HpDown();
        }
    }

    private void HpDown()
    {
        curHp--;

        Debug.Log("DD");

        rigid.velocity = Vector2.left * 3;

        if (curHp <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void ItemDrop()
    {
        InventoryManager.Instance.GetRandomItemSpawn();
    }
}
