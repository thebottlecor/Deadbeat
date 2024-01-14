using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;


public class CalendarUI : EventListener
{

    public TextMeshProUGUI tmp;

    protected override void AddListeners()
    {
        GM.DayChangedEvent += OnDayChanged;
    }

    protected override void RemoveListeners()
    {
        GM.DayChangedEvent -= OnDayChanged;
    }

    private void OnDayChanged(object sender, int e)
    {
        string[] tempweek = new string[]
        {
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday",
            "Sunday",
        };
        int day = e % 7;

        tmp.text = $"Day {e + 1}\n{tempweek[day]}";
    }
}
