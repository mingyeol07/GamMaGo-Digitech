using System.Collections;
using UnityEngine;

public class Axe : Item
{
    private bool isAttack;
    private Transform playerTransform;

    protected override void Start()
    {
        base.Start();

        // �÷��̾��� �ڽ����� ���� ����
        playerTransform = GameManager.Instance.Player.transform;
        transform.parent = playerTransform;
        transform.localPosition = new Vector3(1, 0, 0); // �÷��̾� ���� ������ ��ġ ����
    }

    private void Update()
    {
        if (isAttack)
        {
            // �ִϸ��̼� ���� �߰����� ���� �ʿ��ϴٸ� ���⿡ �ۼ�
        }
    }

    public override void ActSkill()
    {
        if (!isAttack)
        {
            StartCoroutine(AttackRoutine());
        }
    }

    private IEnumerator AttackRoutine()
    {
        isAttack = true;
        float duration = 0.5f; // �ִϸ��̼� �ð� (��)
        float elapsedTime = 0f;

        // ������ �ʱ� ȸ�� ���� ����
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = startRotation * Quaternion.Euler(0, 0, 360);

        // �ִϸ��̼� ���� ȸ��
        while (elapsedTime < duration)
        {
            transform.rotation = Quaternion.Lerp(startRotation, endRotation, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.rotation = startRotation; // ���� ȸ������ ����
        isAttack = false;
    }
}
