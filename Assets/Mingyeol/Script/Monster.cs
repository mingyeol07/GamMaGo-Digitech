using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Monster : MonoBehaviour
{
    private ColorType colorType;
    public ColorType _ColorType { get { return colorType; } }

    private int maxHp;
    private int curHp;

    bool isPlayerAttack;

    private Transform playerTransform;

    private void Start()
    {
        curHp = maxHp;
        playerTransform = GameManager.Instance.Player.transform;
        StartCoroutine(Co_AttackLoop());
    }

    private void Update()
    {
        PlayerCheck();
    }

    private IEnumerator Co_AttackLoop()
    {
        while (true)
        {
            Attack();
            yield return new WaitForSeconds(1);
        }
    }

    private void PlayerCheck()
    {
        bool isPlayerCheck = Physics2D.OverlapCircle(transform.position, 5f, LayerMask.GetMask("Player"));
        isPlayerAttack = Physics2D.OverlapCircle(transform.position, 3f, LayerMask.GetMask("Player"));

        if (isPlayerCheck && !isPlayerAttack)
        {
            transform.position = new Vector2(Mathf.Lerp(transform.position.x, playerTransform.position.x, Time.deltaTime * 5), 0);
        }
    }

    protected virtual void Attack()
    {
        if(isPlayerAttack)
        {

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("PlayerAttack"))
        {
            HpDown();
        }
    }

    private void HpDown()
    {
        if (curHp > 0)
        {
            curHp--;
        }

        if(curHp < 0)
        {
            Destroy(gameObject);
        }
    }
}
