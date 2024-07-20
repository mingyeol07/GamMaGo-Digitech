using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemIconManager : MonoBehaviour
{
    [SerializeField] private Transform[] itemsTransform;
    [SerializeField] private float itemMoveSpeed;
    [SerializeField] private GameObject iconPrefab;
    [SerializeField] private Sprite[] typeSprite;

    private List<GameObject> itemIconList = new List<GameObject>();

    private void Update()
    {
        SortingItems();
    }

    public void SortingItems()
    {
        for (int i = 0; i < itemIconList.Count; i++)
        {
            if (itemIconList[i] != null)
            {
                float iconX = itemIconList[i].transform.position.x;
                float iconBoxX = itemsTransform[i].transform.position.x;

                if (!Mathf.Approximately(iconX, iconBoxX))
                {
                    itemIconList[i].transform.position = new Vector2(
                        Mathf.Lerp(iconX, iconBoxX, Time.deltaTime * itemMoveSpeed),
                        itemIconList[i].transform.position.y
                    );
                }
            }
        }
    }

    public void AddItemIcon(ItemData data, int randomColorIndex)
    {
        if (itemIconList.Count >= itemsTransform.Length)
        {
            Debug.LogWarning("아이콘을 추가할 수 있는 공간이 부족합니다.");
            return;
        }

        GameObject icon = Instantiate(iconPrefab, itemsTransform[itemIconList.Count].position, Quaternion.identity, itemsTransform[itemIconList.Count]);
        icon.GetComponent<IconData>().SetItemData(data, typeSprite[randomColorIndex], randomColorIndex);
        itemIconList.Add(icon);
    }

    public int GetItemListIndexColorType(int index)
    {
        return itemIconList[index].GetComponent<IconData>().RanType;
    }

    public void RemoveSkill(int skillIconIndex)
    {
        if (skillIconIndex < 0 || skillIconIndex >= itemIconList.Count)
        {
            Debug.LogWarning("잘못된 인덱스입니다.");
            return;
        }

        GameObject iconToRemove = itemIconList[skillIconIndex];
        if (iconToRemove != null)
        {
            iconToRemove.GetComponent<IconData>().Acting();
            itemIconList.RemoveAt(skillIconIndex);
        }
    }
}
