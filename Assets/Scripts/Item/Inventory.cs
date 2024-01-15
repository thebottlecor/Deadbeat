using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : Singleton<Inventory>
{

    [SerializeField] private Transform itemParent;
    [SerializeField] private Transform itemSpawnPos;
    [SerializeField] private GameObject itemSource;

    public void Buy(ShoppingItemType itemType, int stack)
    {
        for (int i = 0; i < stack; i++)
        {
            var obj = Instantiate(itemSource, itemSpawnPos.position + UnityEngine.Random.Range(-0.1f, 0.1f) * new Vector3(1f, 1f ,0f), Quaternion.identity, itemParent);
            Item item = obj.GetComponent<Item>();
            item.Init(itemType);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;

            var coll = Physics2D.OverlapPoint(mousePos, LayerMask.GetMask("Item"));

            if (coll != null)
            {
                Item item = coll.GetComponent<Item>();
                item.Use();
            }
        }
    }
}
