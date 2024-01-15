using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;


public class InternetUI : Singleton<InternetUI>
{

    public GameObject panel;
    public Dictionary<int, InternetSubPanel> subPanel;

    [SerializeField] private Button backButton;

    private void Start()
    {
        var tempPanels = GetComponents<InternetSubPanel>();
        subPanel = new Dictionary<int, InternetSubPanel>();
        for (int i = 0; i < tempPanels.Length; i++)
        {
            subPanel.Add(tempPanels[i].Index, tempPanels[i]);
        }

        backButton.onClick.AddListener(Close);
    }

    public void FirstOpen()
    {
        panel.SetActive(true);
        Open(0);
    }

    public void Open(int index)
    {
        foreach (var temp in subPanel)
        {
            if (temp.Key == index)
            {
                subPanel[temp.Key].Open_withScript();
                subPanel[temp.Key].selfButton_active.gameObject.SetActive(true);
                subPanel[temp.Key].selfButton_inactive.gameObject.SetActive(false);
            }
            else
            {
                subPanel[temp.Key].Close();
                subPanel[temp.Key].selfButton_active.gameObject.SetActive(false);
                subPanel[temp.Key].selfButton_inactive.gameObject.SetActive(true);
            }
        }
    }


    private void Close()
    {
        foreach (var temp in subPanel)
        {
            temp.Value.Close();
        }
        panel.SetActive(false);
    }

}
