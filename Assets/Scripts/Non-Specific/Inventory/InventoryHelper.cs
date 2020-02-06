using System;
using MoreMountains.InventoryEngine;
using UnityEngine;
using UnityEngine.Events;


/// <summary>
/// Class is used for adding behavior to inventory manipulations (such as logging or checking conditions)
/// All inventory manipulations that need to be logged should go through this 
/// </summary>
public class InventoryHelper : MonoBehaviour
{
    public static InventoryHelper Instance;
    public UnityEvent CheckOnAdd;
    [SerializeField] private Inventory _inventory;

    private void Awake()
    {
        // Singleton pattern
        if (Instance == null) Instance = this;
        else Destroy(this);
    }

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
