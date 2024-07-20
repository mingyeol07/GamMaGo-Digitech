using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Monster
{
    protected override void Attack()
    {
        if (isPlayerAttack && !isAttack)
        {

        }
    }
    private IEnumerator Co_Attack()
    {
        yield return null;
    }
}
