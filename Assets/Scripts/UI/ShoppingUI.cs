using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ShoppingUI : MonoBehaviour
{


    public GameObject panel;
    public GameObject soldOutUI;

    [Header("¼îÇÎ UI »ý¼º")]
    [SerializeField] private GameObject shoppingItemUISource;
    [SerializeField] private int shoppingItemUICount = 3;
    [SerializeField] private Transform shoppingItemUIParent;
    [SerializeField] private List<ShoppingItemUI> shoppingItemUIs;

    //[Space]


    private void Start()
    {
        Init();
    }

    public void Init()
    {
        shoppingItemUIs = new List<ShoppingItemUI>(shoppingItemUICount);
        for (int i = 0; i < shoppingItemUICount; i++)
        {
            var obj = Instantiate(shoppingItemUISource, shoppingItemUIParent);
            ShoppingItemUI shoppingItemUI = obj.GetComponent<ShoppingItemUI>();
            shoppingItemUI.Init(i);
            shoppingItemUIs.Add(shoppingItemUI);
        }
        UIUpdate();
    }

    public void PanelToggle()
    {
        if (panel.activeSelf)
        {
            panel.SetActive(false);
        }
        else
        {
            panel.SetActive(true);
        }
    }

    public void UIUpdate()
    {
        for (int i = 0; i < shoppingItemUIs.Count; i++)
        {
            shoppingItemUIs[i].UIUpdate();
        }
    }

}
