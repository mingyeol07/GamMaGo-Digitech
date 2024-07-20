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

        // ����
        rigid.AddForce(Vector2.up * 10, ForceMode2D.Impulse);

        Vector2 direction = (GameManager.Instance.Player.transform.position - transform.position).normalized;
        // ��� ��� (�����ϴ� ����)
        yield return new WaitForSeconds(0.5f);

        // �÷��̾�� ����

        rigid.velocity = new Vector2(direction.x * 10, direction.y * 10);

        // ���� ���� �ð�
        yield return new WaitForSeconds(2.5f);



        // ���� ���� �� �ʱ�ȭ
        rigid.velocity = Vector2.zero;
        isAttack = false;
    }
}