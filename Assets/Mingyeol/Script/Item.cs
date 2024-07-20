using UnityEngine;

public abstract class Item : MonoBehaviour
{
    private ColorType colorType;

    /// <summary>
    /// ��ų ����
    /// </summary>
    public abstract void ActSkill();

    public void SetColorType(ColorType type)
    {
        colorType = type;
    }
}
