using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoppingManager : Singleton<ShoppingManager>
{

    [SerializeField] private ShoppingItemLibrary shoppingItemLibrary;
    public Dictionary<ShoppingItemType, ShoppingItemInfo> shoppingItemDic;

    [System.Serializable]
    public struct MarketInfo
    {
        public ShoppingItemType itemType;
        public float priceModify; // 0.5f ~ 2.0f
        public int sellStack; // 기본 1 이상

        public bool sold;

        public int GetPrice()
        {
            int basePrice = Instance.shoppingItemDic[itemType].basePrice;
            int price = Mathf.RoundToInt((basePrice * sellStack) * priceModify);
            return price;
        }
        public int GetBasePrice()
        {
            return Instance.shoppingItemDic[itemType].basePrice;
        }
        public Sprite GetSprite()
        {
            return Instance.shoppingItemDic[itemType].sprite;
        }
    }

    public List<MarketInfo> sellGoods;
    public bool sold;

    public ShoppingUI shoppingUI;

    protected override void Awake()
    {
        base.Awake();

        shoppingItemDic = shoppingItemLibrary.GetHashMap();
        SetSellGoods_Random();
    }

    public void SetSellGoods_Random()
    {
        SetSold(false);
        sellGoods = new List<MarketInfo>();

        foreach (var temp in shoppingItemLibrary.categories)
        {
            int count = 1;
            if (temp.Key == ShoppingItemCategory.hungry)
            {
                count = 2;
            }

            for (int i = 0; i < count; i++)
            {
                int randomIndex = UnityEngine.Random.Range(0, temp.Value.Count);
                float randomPriceModify = UnityEngine.Random.Range(5, 21) * 0.1f;
                int randomSellStack = UnityEngine.Random.Range(1, 4);

                MarketInfo marketInfo = new MarketInfo
                {
                    itemType = temp.Value[randomIndex],
                    priceModify = randomPriceModify,
                    sellStack = randomSellStack,
                };

                sellGoods.Add(marketInfo);
            }
        }

        int max = 1;
        for (int i = 0; i < max; i++)
        {
            int randomIndex = UnityEngine.Random.Range(0, shoppingItemLibrary.itemTypes.Count);
            float randomPriceModify = UnityEngine.Random.Range(5, 21) * 0.1f;
            int randomSellStack = UnityEngine.Random.Range(1, 4);

            MarketInfo marketInfo = new MarketInfo
            {
                itemType = shoppingItemLibrary.itemTypes[randomIndex],
                priceModify = randomPriceModify,
                sellStack = randomSellStack,
            };

            sellGoods.Add(marketInfo);
        }

        shoppingUI.UIUpdate();
    }

    public void BuyAndUse(int index)
    {
        if (sold) return;
        if (index >= sellGoods.Count) return;

        var goods = sellGoods[index];

        if (goods.sold) return;
        if (goods.sellStack <= 0) return;

        int price = goods.GetPrice();
        if (GM.Instance.Gold >= price)
        {
            int stack = goods.sellStack;
            // Buy
            GM.Instance.SetGold(GM.Instance.Gold - price);
            goods.sold = true;
            goods.sellStack = 0;
            sellGoods[index] = goods;

            // Use
            // 지금은 즉시 사용
            shoppingItemDic[goods.itemType].Use(stack);

            //SetSold(true);

            shoppingUI.UIUpdate();
        }

    }

    public void SetSold(bool on)
    {
        if (on)
        {
            sold = true;
            shoppingUI.soldOutUI.SetActive(true);
        }
        else
        {
            sold = false;
            shoppingUI.soldOutUI.SetActive(false);
        }
    }

}
