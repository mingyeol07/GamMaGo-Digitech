using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ColorType
{
    White
}

public class PickUpItem : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Transform playerTransform;

    private ItemData itemData;
    private ColorType type;

    private int randomTypeIndex;
    private float speed;
    private float startTime;

    private Vector3[] poses = new Vector3[4];
    private Vector3 initialPosition;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        startTime = Time.time;
        initialPosition = transform.position;
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
        if (playerTransform != null)
        {
            float t = (Time.time - startTime) * speed;
            t = t * t;

            transform.position = Vector3.Lerp(initialPosition, playerTransform.position, t * Time.deltaTime);
        }
    }

    public void ItemPickUp()
    {
        InventoryManager.Instance.AddItem(itemData, randomTypeIndex);
    }
}
