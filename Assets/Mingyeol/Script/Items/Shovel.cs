using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shovel : Item
{
    protected override void Start()
    {
        base.Start();
    }

    public override void ActSkill()
    {
        AudioManager.instance.SetSounds(1);
        GameManager.Instance.Player.GetComponent<Player>().BoldSlash();
        GameManager.Instance.playerAnim.SetTrigger("Shovel");
    }
}
