using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pick : Item
{
    protected override void Start()
    {
        base.Start();
    }

    public override void ActSkill()
    {
        AudioManager.instance.SetSounds(1);
        GameManager.Instance.Player.GetComponent<Player>().SharpSlash();
        GameManager.Instance.playerAnim.SetTrigger("Pick");
    }
}
