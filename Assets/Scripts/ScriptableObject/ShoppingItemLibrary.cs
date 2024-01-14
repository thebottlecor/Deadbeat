using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

[CreateAssetMenu(fileName = "ShoppingItemLibrary", menuName = "Shopping/New ShoppingItemLibrary")]
public class ShoppingItemLibrary : ScriptableObject
{
    [SerializeField] private ShoppingItemInfo[] items = null;

    public Dictionary<ShoppingItemCategory, List<ShoppingItemType>> categories; // 음식,위생용품,행복관련 카테고리별 집합
    public List<ShoppingItemType> itemTypes; // 단순한 집합


    public Dictionary<ShoppingItemType, ShoppingItemInfo> GetHashMap()
    {
        categories = new Dictionary<ShoppingItemCategory, List<ShoppingItemType>>();
        var temp = Enum.GetValues(typeof(ShoppingItemCategory));
        for (int i = 0; i < temp.Length; i++)
        {
            categories.Add((ShoppingItemCategory)temp.GetValue(i), new List<ShoppingItemType>());
        }
        itemTypes = new List<ShoppingItemType>();

        Dictionary<ShoppingItemType, ShoppingItemInfo> hashMap = new Dictionary<ShoppingItemType, ShoppingItemInfo>();
        foreach (var item in items)
        {
            if (hashMap.ContainsKey(item.itemType))
                continue;

            categories[item.category].Add(item.itemType);
            itemTypes.Add(item.itemType);

            hashMap.Add(item.itemType, item);
        }
        return hashMap;
    }
}
