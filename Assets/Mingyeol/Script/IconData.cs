using UnityEngine;
using UnityEngine.UI;

public class IconData : MonoBehaviour
{
    [SerializeField] private Image img_icon;
    [SerializeField] private Image img_colorIcon;
    int ranType;
    public int RanType { get { return ranType; } }

    public void SetItemData(ItemData data, Sprite ranColorBackSprite, int ran)
    {
        var itemData = data;
        img_icon.sprite = data.Icon;
        ranType = ran;
        img_colorIcon.sprite = ranColorBackSprite;
    }

    public void Acting()
    {
        Destroy(gameObject);
    }
}
