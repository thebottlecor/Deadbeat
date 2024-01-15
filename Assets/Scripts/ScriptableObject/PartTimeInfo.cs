using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PartTimeType
{
    labor,
    service,
    clean,
    minigame,
}


[CreateAssetMenu(fileName = "PartTime", menuName = "Shopping/New PartTime")]
[Serializable]
public class PartTimeInfo : ScriptableObject
{
    public PartTimeType itemType;
    public Sprite sprite;
    public int wage;

    [Serializable]
    public struct Effect
    {
        public GM.Stat.StatType statType;
        public float statValue;
    }

    [SerializeField] private Effect[] effects;

    public void Work(int mul = 1)
    {
        if (wage > 0f)
        {
            for (int i = 0; i < effects.Length; i++)
            {
                GM.Instance.stats[(int)effects[i].statType].AddValue(effects[i].statValue * mul);
            }
            GM.Instance.AddGold(wage * mul);
            GM.Instance.DeadCheck();
        }
        else
        {
            MinigameManager.Instance.GameStart();
        }
    }
}
