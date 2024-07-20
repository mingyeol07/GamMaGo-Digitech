using System.Collections;
using UnityEngine;

public class Goblin : Monster
{
    protected override void Attack()
    {
        if (isPlayerAttack && !isAttack)
        {
            StartCoroutine(Co_Attack());
        }
    }

    private IEnumerator Co_Attack()
    {
        isAttack = true;

        // 점프
        rigid.AddForce(Vector2.up * 10, ForceMode2D.Impulse);

        Vector2 direction = (GameManager.Instance.Player.transform.position - transform.position).normalized;
        // 잠깐 대기 (점프하는 동안)
        yield return new WaitForSeconds(0.5f);

        // 플레이어에게 돌진

        rigid.velocity = new Vector2(direction.x * 10, direction.y * 10);

        // 공격 지속 시간
        yield return new WaitForSeconds(2.5f);



        // 공격 종료 후 초기화
        rigid.velocity = Vector2.zero;
        isAttack = false;
    }
}