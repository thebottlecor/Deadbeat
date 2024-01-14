using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class GM : Singleton<GM>
{

    public int day;

    public int Gold { get; private set; }
    [SerializeField] private int initGold = 100000;
    public TextMeshProUGUI goldTmp;

    [Serializable]
    public class Stat
    {
        public enum StatType
        {
            hungry,
            health,
            happiness,
        }
        [SerializeField] private StatType statType;

        public float Value { get; private set; }
        [SerializeField] private float base_Max = 100f;
        public float Max
        {
            get
            {
                float value = base_Max;
                return value;
            }
        }
        [SerializeField] private float base_decreaseDaily = 33f;
        public float DecreaseDaily
        {
            get
            {
                float value = base_decreaseDaily;
                return value;
            }
        }
        public static EventHandler<StatType> StatChangedEvent;

        public void Init()
        {
            SetValue(Max);
        }

        public void SetValue(float value)
        {
            this.Value = value;
            SetLimit();
        }
        public void AddValue(float value)
        {
            this.Value += value;
            SetLimit();
        }

        public void DailyUpdate()
        {
            AddValue(-1f * DecreaseDaily);
        }

        private void SetLimit()
        {
            if (Value > Max)
                Value = Max;
            else if (Value < 0f)
                Value = 0f;

            if (StatChangedEvent != null)
                StatChangedEvent(this, statType);
        }
    }

    public Stat hungry;
    public Stat health;
    public Stat happiness;
    public List<Stat> stats;

    public ShoppingUI shoppingUI;
    public GameObject gameoverUI;

    public NightUI nightUI;

    public bool Loading { get; private set; }

    public static EventHandler<int> DayChangedEvent;


    private void Start()
    {
        InitStat();
    }

    public void InitStat()
    {
        SetDay(0);
        SetGold(initGold);

        //int statCount = Enum.GetValues(typeof(Stat.StatType)).Length;
        stats = new List<Stat> { hungry, health, happiness };
        for (int i = 0; i < stats.Count; i++)
        {
            stats[i].Init();
        }
    }

    public void SetDay(int value)
    {
        day = value;
        if (DayChangedEvent != null)
            DayChangedEvent(null, day);
    }

    public void SetGold(int value)
    {
        Gold = value;
        goldTmp.text = $"{Gold}G";
    }

    public void NextDay_ButtonClick()
    {
        if (Loading) return;

        StartCoroutine(NextDay());
    }

    public IEnumerator NextDay()
    {
        Loading = true;
        SetDay(day + 1);
        nightUI.Toggle(true, day);

        // ´ë±â
        yield return new WaitForSeconds(1f);

        for (int i = 0; i < stats.Count; i++)
        {
            stats[i].DailyUpdate();
            if (stats[i].Value <= 0)
            {
                gameoverUI.SetActive(true);
                break;
            }
        }

        ShoppingManager.Instance.SetSellGoods_Random();

        nightUI.Toggle(false);
        Loading = false;
    }
}
