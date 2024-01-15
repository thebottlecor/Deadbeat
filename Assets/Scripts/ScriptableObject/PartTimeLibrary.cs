using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

[CreateAssetMenu(fileName = "PartTimeLibrary", menuName = "Shopping/New PartTimeLibrary")]
public class PartTimeLibrary : ScriptableObject
{
    [SerializeField] private PartTimeInfo[] items = null;

    public List<PartTimeType> itemTypes; // 단순한 집합


    public Dictionary<PartTimeType, PartTimeInfo> GetHashMap()
    {
        itemTypes = new List<PartTimeType>();

        Dictionary<PartTimeType, PartTimeInfo> hashMap = new Dictionary<PartTimeType, PartTimeInfo>();
        foreach (var item in items)
        {
            if (hashMap.ContainsKey(item.itemType))
                continue;

            itemTypes.Add(item.itemType);

            hashMap.Add(item.itemType, item);
        }
        return hashMap;
    }
}
