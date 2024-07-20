using UnityEngine;
using UnityEngine.UI;

public class IconData : MonoBehaviour
{
    [SerializeField] private Image img_icon;
    [SerializeField] private Image img_colorIcon;

    public void SetItemData(ItemData data, Sprite ranColorBackSprite)
    {
        var itemData = data;
        img_colorIcon.sprite = ranColorBackSprite;
    }

    public void Acting()
    {
        Destroy(gameObject);
    }
}
