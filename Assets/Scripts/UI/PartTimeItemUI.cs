using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class PartTimeItemUI : MonoBehaviour
{

    public Image icon;
    public Button doButton;
    public TextMeshProUGUI priceTMP;

    private int index;

    public void Init(int index)
    {
        this.index = index;
    }

    public void UIUpdate()
    {
        var info = PartTimeManager.Instance.partTimes[index];
        icon.sprite = info.GetSprite();

        priceTMP.text = string.Empty;
    }

    public void Do()
    {
        PartTimeManager.Instance.Work(index);
    }

}
