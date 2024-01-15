using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    public ShoppingItemType itemType;
    public SpriteRenderer sprite;

    public void Init(ShoppingItemType itemType)
    {
        this.itemType = itemType;
        sprite.sprite = ShoppingManager.Instance.shoppingItemDic[itemType].sprite;
    }

    public void Use()
    {
        ShoppingManager.Instance.shoppingItemDic[itemType].Use();
        Destroy(this.gameObject);
    }
}
