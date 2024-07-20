using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    [SerializeField] private List<ItemData> itemList;
    private List<ItemData> items = new List<ItemData>();
    [SerializeField] private Animator animtor_backPack;
    [SerializeField] private Animator animtor_player;

    private ItemIconManager iconManager;
    private readonly int hash_level = Animator.StringToHash("Level");
    public int level = 0;

    [SerializeField] private GameObject pickUpItemPrefab;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        iconManager = GetComponent<ItemIconManager>();
    }

    private void Update()
    {
        SetBackPackAnimator();
    }

    public GameObject GetRandomItemSpawn()
    {
        return Instantiate(pickUpItemPrefab);
    }

    private void SetBackPackAnimator()
    {
        int newLevel = 0;

        if (items.Count > 0 && items.Count <= 2)
        {
            newLevel = 2;
        }
        else if (items.Count > 2 && items.Count <= 4)
        {
            newLevel = 3;
        }
        else if (items.Count > 4)
        {
            newLevel = 4;
        }

        if (newLevel != level)
        {
            level = newLevel;
            animtor_player.Rebind();
            animtor_backPack.SetInteger(hash_level, level);
        }
    }

    public ItemData GetRandomItem()
    {
        return itemList[Random.Range(0, itemList.Count)];
    }

    public void SkillActing(int skillIndex)
    {
        if (skillIndex < 0 || skillIndex >= items.Count)
        {
            Debug.LogWarning("잘못된 인덱스입니다.");
            return;
        }

        // 아이템 소환
        GameObject item = Instantiate(items[skillIndex].ItemPrefab);
        item.transform.position = GameManager.Instance.Player.transform.position;
        item.GetComponent<Item>().SetColorType((ColorType)iconManager.GetItemListIndexColorType(skillIndex));

        items.RemoveAt(skillIndex);

        iconManager.RemoveSkill(skillIndex);
        iconManager.SortingItems();
    }

    public void AddItem(ItemData addItem, int randomColorIndex)
    {
        if (itemList.Count >= 10) // 최대 크기를 10으로 설정
        {
            GameManager.Instance.GameOver();
            return;
        }

        items.Add(addItem);
        iconManager.AddItemIcon(addItem, randomColorIndex);
        iconManager.SortingItems();
    }
}
