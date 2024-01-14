using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ShoppingItemType
{
    apple,
    cola,
    mushroom,
    toothbrush,
    toothpaste,
    doll,
}

public enum ShoppingItemCategory
{
    hungry,
    health,
    happiness,
}


[CreateAssetMenu(fileName = "ShoppingItem", menuName = "Shopping/New ShoppingItem")]
[Serializable]
public class ShoppingItemInfo : ScriptableObject
{
    public ShoppingItemCategory category;
    public ShoppingItemType itemType;
    public Sprite sprite;
    public int basePrice;

    [Serializable]
    public struct Effect
    {
        public GM.Stat.StatType statType;
        public float statValue;
    }

    [SerializeField] private Effect[] effects;

    public void Use(int mul = 1)
    {
        for (int i = 0; i < effects.Length; i++)
        {
            GM.Instance.stats[(int)effects[i].statType].AddValue(effects[i].statValue * mul);
        }
    }
}
