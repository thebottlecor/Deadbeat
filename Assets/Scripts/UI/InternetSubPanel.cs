using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public abstract class InternetSubPanel : MonoBehaviour
{

    [SerializeField] private int index;
    public int Index => index;

    public GameObject panel;
    public GameObject soldOutUI;

    public Button selfButton_active;
    public Button selfButton_inactive;

    private void Awake()
    {
        selfButton_active.onClick.AddListener(Open);
        selfButton_inactive.onClick.AddListener(Open);
    }

    public void Open()
    {
        InternetUI.Instance.Open(index);
    }
    public void Open_withScript()
    {
        panel.SetActive(true);
    }


    public void Close()
    {
        panel.SetActive(false);
    }

}
