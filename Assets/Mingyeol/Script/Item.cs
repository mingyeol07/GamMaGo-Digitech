using UnityEngine;

public abstract class Item : MonoBehaviour
{
    private ColorType colorType;

    /// <summary>
    /// 스킬 구현
    /// </summary>
    public abstract void ActSkill();

    public void SetColorType(ColorType type)
    {
        colorType = type;
    }
}
