using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class StatUI : EventListener
{

    [SerializeField] private GM.Stat.StatType statType;
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI tmp;

    [SerializeField] private TextMeshProUGUI floatingTMP;

    protected override void AddListeners()
    {
        GM.Stat.StatChangedEvent += OnStatChanged;
    }

    protected override void RemoveListeners()
    {
        GM.Stat.StatChangedEvent -= OnStatChanged;
    }

    float prevValue;

    private void OnStatChanged(object sender, GM.Stat.StatType e)
    {
        if (e == statType)
        {
            GM.Stat stat = sender as GM.Stat;

            float differ = stat.Value - prevValue;
            prevValue = stat.Value;

            UIUpdate(stat.Value);
            FloatingUIUpdate(differ);
        }
    }

    public void UIUpdate(float value)
    {
        tmp.text = $"{value:F0}%";
    }

    private void FloatingUIUpdate(float value)
    {
        floatingTMP.gameObject.SetActive(true);
        if (value >= 0f)
        {
            floatingTMP.text = $"+{value:F0}";
        }
        else if (value < 0f)
        {
            floatingTMP.text = $"{value:F0}";
        }
    }
}
