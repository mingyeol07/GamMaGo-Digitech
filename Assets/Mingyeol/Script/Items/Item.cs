using UnityEngine;

public abstract class Item : MonoBehaviour
{
    private ColorType colorType;
    [SerializeField] private float destoryTime;

    protected virtual void Start()
    {
        Destroy(gameObject, destoryTime);
        ActSkill();
    }
    /// <summary>
    /// 스킬 구현
    /// </summary>
    public abstract void ActSkill();

    public void SetColorType(ColorType type)
    {
        colorType = type;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Monster"))
        {
            if (collision.gameObject.GetComponent<Monster>()._ColorType == colorType)
            {

            }
        }
    }
}
