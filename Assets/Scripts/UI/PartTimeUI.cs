using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class PartTimeUI : InternetSubPanel
{

    [Header("알바 UI 생성")]
    [SerializeField] private GameObject partTimeItemUISource;
    [SerializeField] private Transform partTimeItemUIParent;
    [SerializeField] private List<PartTimeItemUI> partTimeItemUIs;

    //[Space]


    private void Start()
    {
        Init();
    }

    public void Init()
    {
        int count = PartTimeManager.Instance.partTimeDic.Count;
        partTimeItemUIs = new List<PartTimeItemUI>(count);
        for (int i = 0; i < count; i++)
        {
            var obj = Instantiate(partTimeItemUISource, partTimeItemUIParent);
            PartTimeItemUI itemUI = obj.GetComponent<PartTimeItemUI>();
            itemUI.Init(i);
            partTimeItemUIs.Add(itemUI);
        }
        UIUpdate();
    }

    public void UIUpdate()
    {
        for (int i = 0; i < partTimeItemUIs.Count; i++)
        {
            partTimeItemUIs[i].UIUpdate();
        }
    }

}
