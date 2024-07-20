using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    private ColorType colorType;
    public ColorType _ColorType { get { return colorType; } }

    private int maxHp;
    private int curHp;

    private void Start()
    {
        curHp = maxHp;
    }

    private void Update()
    {
       
        
    }

    private void PlayerCheck()
    {
        bool isPlayerCheck = Physics2D.OverlapCircle(transform.position, 5f, LayerMask.GetMask("Player"));

        if(isPlayerCheck)
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
