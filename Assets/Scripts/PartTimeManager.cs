using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartTimeManager : Singleton<PartTimeManager>
{

    [SerializeField] private PartTimeLibrary partTimeLibrary;
    public Dictionary<PartTimeType, PartTimeInfo> partTimeDic;

    [System.Serializable]
    public struct EmploymentInfo
    {
        public PartTimeType itemType;
        public Sprite GetSprite()
        {
            return Instance.partTimeDic[itemType].sprite;
        }
    }

    public List<EmploymentInfo> partTimes;

    public PartTimeUI panelUI;
    private bool workLimit;

    protected override void Awake()
    {
        base.Awake();

        partTimeDic = partTimeLibrary.GetHashMap();
        SetEmployment();
    }

    public void ResetWorkLimit()
    {
        SetSold(false);
    }

    public void SetEmployment()
    {
        partTimes = new List<EmploymentInfo>();
        
        foreach (var temp in partTimeDic)
        {
            EmploymentInfo info = new EmploymentInfo
            {
                itemType = temp.Key,
            };

            partTimes.Add(info);
        }

        panelUI.UIUpdate();
    }

    public void Work(int index)
    {
        if (workLimit) return;
        if (index >= partTimes.Count) return;

        var works = partTimes[index];

        // Use
        // 지금은 즉시 사용
        partTimeDic[works.itemType].Work();

        SetSold(true);

        panelUI.UIUpdate();
    }

    public void SetSold(bool on)
    {
        if (on)
        {
            workLimit = true;
            panelUI.soldOutUI.SetActive(true);
        }
        else
        {
            workLimit = false;
            panelUI.soldOutUI.SetActive(false);
        }
    }

}
