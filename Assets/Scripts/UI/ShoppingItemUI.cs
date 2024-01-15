using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ShoppingItemUI : MonoBehaviour
{

    public Image icon;
    public Button doButton;
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

        if (info.priceModify > 1f)
            priceTMP.text = $"<color=#ff0000>{info.GetPrice()}G ({info.priceModify:P0})";
        else if (info.priceModify == 1f)
            priceTMP.text = $"<color=#000000>{info.GetPrice()}G ({info.priceModify:P0})";
        else
            priceTMP.text = $"<color=#0000ff>{info.GetPrice()}G ({info.priceModify:P0})";
    }

    public void Do()
    {
        ShoppingManager.Instance.BuyAndUse(index);
    }

}
