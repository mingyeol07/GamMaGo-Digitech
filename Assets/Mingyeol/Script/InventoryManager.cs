using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    [SerializeField] private List<ItemData> itemList;

    private ItemIconManager iconManager;

    private void Awake()
    {
        Instance = this;
        iconManager = GetComponent<ItemIconManager>();
    }

    public ItemData GetRandomItem()
    {
        return itemList[Random.Range(0, itemList.Count)];
    }

    public void SkillActing(int skillIndex)
    {
        GameObject item = Instantiate(itemList[skillIndex].ItemPrefab);
        item.transform.position = GameManager.Instance.Player.transform.position;
        itemList.RemoveAt(skillIndex);

        iconManager.RemoveSkill(skillIndex);
        iconManager.SortingItems();
    }

    public void AddItem(ItemData addItem, int randomColorIndex)
    {
        if (itemList.Count > 9) return;

        itemList.Add(addItem);

        iconManager.AddItemIcon(addItem, randomColorIndex);
        iconManager.SortingItems();
    }
}
