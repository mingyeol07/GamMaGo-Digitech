using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : Item
{
    private bool isShooting;
    private Rigidbody2D rigid;

    private void Start()
    {
       rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(isShooting)
        {
            Shooting();
        }
    }

    private void Shooting()
    {
        rigid.velocity = transform.right * 5;
    }

    public override void ActSkill()
    {
        transform.rotation = Quaternion.Euler(0, GameManager.Instance.Player.transform.eulerAngles.y, 0);

        isShooting = true;
    }
}
