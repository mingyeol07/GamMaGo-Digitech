using System.Collections;
using UnityEngine;

public class Axe : Item
{
    private bool isAttack;
    private Transform playerTransform;

    protected override void Start()
    {
        base.Start();

        // 플레이어의 자식으로 도끼 설정
        playerTransform = GameManager.Instance.Player.transform;
        transform.parent = playerTransform;
        transform.localPosition = new Vector3(1, 0, 0); // 플레이어 기준 도끼의 위치 조정
    }

    private void Update()
    {
        if (isAttack)
        {
            // 애니메이션 동안 추가적인 논리가 필요하다면 여기에 작성
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
        float duration = 0.5f; // 애니메이션 시간 (초)
        float elapsedTime = 0f;

        // 도끼의 초기 회전 값을 저장
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = startRotation * Quaternion.Euler(0, 0, 360);

        // 애니메이션 동안 회전
        while (elapsedTime < duration)
        {
            transform.rotation = Quaternion.Lerp(startRotation, endRotation, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.rotation = startRotation; // 원래 회전으로 복귀
        isAttack = false;
    }
}
