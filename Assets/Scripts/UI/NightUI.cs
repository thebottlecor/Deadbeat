using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NightUI : MonoBehaviour
{
    public TextMeshProUGUI tmp;

    private void OnDayChanged(int e)
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

    public void Toggle(bool on, int day = 0)
    {
        if (on)
        {
            OnDayChanged(day);
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
