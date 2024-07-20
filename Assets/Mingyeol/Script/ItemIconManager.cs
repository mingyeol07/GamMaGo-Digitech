using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class ItemIconManager : MonoBehaviour
{
    [SerializeField] private Transform[] itemsTransform;
    [SerializeField] private float itemMoveSpeed;
    [SerializeField] private GameObject iconPrefab;
    [SerializeField] private RectTransform iconParent;

    [SerializeField] private Sprite[] typeSprite;

    private List<GameObject> itemIconList = new List<GameObject>();

    public void SortingItems()
    {
        for (int i = 0; i < itemIconList.Count - 1; i++)
        {
            if (itemIconList[i] != null)
            {
                float iconX = itemIconList[i].transform.position.x;
                float iconBoxX = itemsTransform[i].transform.position.x;

                if (!Mathf.Approximately(iconX, iconBoxX))
                {
                    itemIconList[i].transform.position =
                        new Vector2(Mathf.Lerp(iconX, iconBoxX, Time.deltaTime * itemMoveSpeed), itemIconList[i].transform.position.y);
                }
            }
        }
    }

    public void AddItemIcon(ItemData data, int randomColorIndex)
    {
        GameObject icon = Instantiate(iconPrefab, itemsTransform[itemIconList.Count].transform);
        icon.GetComponent<IconData>().SetItemData(data, typeSprite[randomColorIndex]);
        itemIconList.Add(icon);
    }

    public void RemoveSkill(int skillIconIndex)
    {
        itemIconList[skillIconIndex].GetComponent<IconData>().Acting();
    }
}
