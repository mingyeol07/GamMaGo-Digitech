using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Monster
{
    [SerializeField] private GameObject attackRange;

    protected override void Attack()
    {
        if (isPlayerAttack && !isAttack)
        {
            StartCoroutine( Co_Attack());
        }
    }

    private IEnumerator Co_Attack()
    {
        isAttack = true;

        GetComponent<Animator>().SetTrigger("IsAttack");

        yield return new WaitForSeconds(2.5f);

        // 공격 종료 후 초기화
        rigid.velocity = Vector2.zero;
        isAttack = false;
    }

    public void AttackToggle()
    {
        attackRange.SetActive(!attackRange.activeSelf);
    }
}
