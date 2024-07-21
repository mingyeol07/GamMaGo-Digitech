using System.Collections;
using UnityEngine;
using DG.Tweening;

public class Axe : Item
{
    public override void ActSkill()
    {
        AudioManager.instance.SetSounds(0);
        GameManager.Instance.Player.GetComponent<Player>().BoldSlash();
        GameManager.Instance.playerAnim.SetTrigger("Axe");
    }

    protected override void Start()
    {
        base.Start();
    }
}
