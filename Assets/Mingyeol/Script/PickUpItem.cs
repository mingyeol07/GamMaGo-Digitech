using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ColorType
{
    Red, Green, Blue
}

public class PickUpItem : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Transform playerTransform;

    private ItemData itemData;
    private ColorType type;

    private int randomTypeIndex;
    private float speed = 1.0f; // 속도 변수 초기화
    private float startTime;

    private bool isPickUp;

    private Vector3 initialPosition;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        playerTransform = GameManager.Instance.Player.transform;



        RandomType();
    }

    private void RandomType()
    {
        randomTypeIndex = Random.Range(0, System.Enum.GetValues(typeof(ColorType)).Length);
        itemData = InventoryManager.Instance.GetRandomItem();

        spriteRenderer.sprite = itemData.ItemSprite;

        type = (ColorType)randomTypeIndex;
    }

    private void Update()
    {
        if (playerTransform != null && isPickUp)
        {
            float t = (Time.time - startTime) * speed;
            t = t * t; // 가속 효과

            if (t > 1.0f) t = 1.0f; // t 값을 1로 클램프

            transform.position = Vector3.Lerp(initialPosition, playerTransform.position, t);
        }
    }

    public void SetIsPickUp()
    {
        if(!isPickUp)
        {
            isPickUp = true;

            startTime = Time.time;
            initialPosition = transform.position;
        }
    }

    public void ItemPickUp()
    {
        InventoryManager.Instance.AddItem(itemData, randomTypeIndex);
    }
}
