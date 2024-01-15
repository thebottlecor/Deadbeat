using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ShoppingUI : InternetSubPanel
{

    [Header("¼îÇÎ UI »ý¼º")]
    [SerializeField] private GameObject shoppingItemUISource;
    [SerializeField] private Transform shoppingItemUIParent;
    [SerializeField] private List<ShoppingItemUI> shoppingItemUIs;

    //[Space]


    private void Start()
    {
        Init();
    }

    public void Init()
    {
        int count = ShoppingManager.Instance.shoppingItemUICount;
        shoppingItemUIs = new List<ShoppingItemUI>(count);
        for (int i = 0; i < count; i++)
        {
            var obj = Instantiate(shoppingItemUISource, shoppingItemUIParent);
            ShoppingItemUI itemUI = obj.GetComponent<ShoppingItemUI>();
            itemUI.Init(i);
            shoppingItemUIs.Add(itemUI);
        }
        UIUpdate();
    }

    public void UIUpdate()
    {
        for (int i = 0; i < shoppingItemUIs.Count; i++)
        {
            shoppingItemUIs[i].UIUpdate();
        }
    }

}
