using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    [SerializeField] private List<ItemData> itemList;
    [SerializeField] private Animator animtor_backPack;
    [SerializeField] private Animator animtor_player;

    private ItemIconManager iconManager;

    private readonly int hash_level = Animator.StringToHash("Level");

    private int level = 0;

    private void Awake()
    {
        Instance = this;
        iconManager = GetComponent<ItemIconManager>();
    }

    private void Update()
    {
        SetBackPackAnimator();
    }

    private void SetBackPackAnimator()
    {
        if(itemList.Count > 2 && itemList.Count <= 4 && level != 2)
        {
            animtor_player.Rebind();
            level = 2;
        }
        else if(itemList.Count > 4 && itemList.Count <= 6 && level != 3)
        {
            animtor_player.Rebind();
            level = 3;
        }
        else if(itemList.Count > 6 && level != 4)
        {
            animtor_player.Rebind();
            level = 4;
        }

        animtor_backPack.SetInteger(hash_level, level);
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
