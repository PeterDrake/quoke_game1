using System.Collections;
using System.Collections.Generic;
using MoreMountains.InventoryEngine;
using UnityEngine;
using UnityEngine.Events;

public class InventoryHelper : MonoBehaviour
{
    public UnityEvent CheckOnAdd;
    // Script to help with adding, checking, removing items
    public Inventory _inventory;

    public void AddItem(BaseItem item, int amt)
    {
        CheckOnAdd.Invoke();
        _inventory.AddItem(item, amt);
    }

    public bool HasItem(BaseItem item, int amt)
    {
        return (_inventory.InventoryContains(item.name).Count >= amt);
    }

    public bool HasItem(BaseItem[] items, int[] amts)
    {
        for (int i = 0; i < items.Length; i++)
            if (!HasItem(items[i], amts[i]))
                return false;
        return true;
    }


}
