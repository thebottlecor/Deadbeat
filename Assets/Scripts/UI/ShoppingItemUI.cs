using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ShoppingItemUI : MonoBehaviour
{

    public Image icon;
    public Button buyButton;
    public TextMeshProUGUI stackTMP;
    public TextMeshProUGUI priceTMP;

    private int index;

    public void Init(int index)
    {
        this.index = index;
    }

    public void UIUpdate()
    {
        var info = ShoppingManager.Instance.sellGoods[index];
        icon.sprite = info.GetSprite();
        stackTMP.text = $"x{info.sellStack}";
        priceTMP.text = $"{info.GetPrice()}G ({info.priceModify:P0})";
    }

    public void Buy()
    {
        ShoppingManager.Instance.BuyAndUse(index);
    }

}
