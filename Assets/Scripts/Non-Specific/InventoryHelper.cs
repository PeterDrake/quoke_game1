using System;
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
        Logger.Instance.Log("Picked up: "+item.name);
        _inventory.AddItem(item, amt);
        CheckOnAdd.Invoke();
    }

    public bool HasItem(BaseItem item, int amt)
    {
        bool value = (_inventory.InventoryContains(item.name).Count >= amt);
        return value;
    }

    public bool HasItem(BaseItem[] items, int[] amts)
    {
        for (int i = 0; i < items.Length; i++)
            if (!HasItem(items[i], amts[i]))
                return false;
        return true;
    }

    public void RemoveItem(BaseItem item)
    {
        if (item == null) return;
       
        int i = Array.FindIndex(_inventory.Content, row => row.ItemID == item.ItemID);
        if (i >= 0) 
        {
            _inventory.RemoveItem(i, 1);
            Logger.Instance.Log("Item removed from inventory"+item.name); 
        }
    }

    public void RemoveItem(BaseItem item, int amt)
    {
        for (int i = 0; i < amt; i++)
        {
            RemoveItem(item);
        }
    }
    
    public void RemoveItem(BaseItem[] items, int[] amts)
    {
        for (int i = 0; i < items.Length; i++)
            RemoveItem(items[i], amts[i]);
    }


}
