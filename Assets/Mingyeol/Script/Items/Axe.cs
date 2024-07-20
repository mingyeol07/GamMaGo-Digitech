using System.Collections;
using UnityEngine;
using DG.Tweening;

public class Axe : Item
{
    public override void ActSkill()
    {
        GameManager.Instance.Player.GetComponent<Player>().BoldSlash();
    }

    protected override void Start()
    {
        base.Start();
    }
}
