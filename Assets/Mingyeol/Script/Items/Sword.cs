using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Item
{
    protected override void Start()
    {
        base.Start();
    }

    public override void ActSkill()
    {
        GameManager.Instance.Player.GetComponent<Player>().SharpSlash();
        GameManager.Instance.playerAnim.SetTrigger("Sword");
    }
}
