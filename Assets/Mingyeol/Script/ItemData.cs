using System;
using UnityEngine;

[Serializable]
public class ItemData
{
    [SerializeField] private Sprite itemSprite;
    public Sprite ItemSprite { get { return itemSprite; } }

    [SerializeField] private Sprite icon;
    public Sprite Icon {  get { return icon; } }

    [SerializeField] private GameObject itemPrefab;
    public GameObject ItemPrefab { get { return itemPrefab; } }
}
