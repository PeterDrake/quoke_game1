using UnityEngine;
using UnityEngine.Events;


/// <summary>
/// Class is used for adding behavior to inventory manipulations (such as logging or checking conditions)
/// All inventory manipulations that need to be logged should go through this 
/// </summary>
public class InventoryHelper : MonoBehaviour
{
    public UnityEvent CheckOnAdd;
    [SerializeField] private OurInventory _inventory;

    public void AddItem(Item item, int amt)
    {
        Logger.Instance.Log("Picked up: "+item.name);
        _inventory.AddItem(item, (byte)amt);
        CheckOnAdd.Invoke();
    }

    public bool HasItem(Item item, int amt)
    {
        return _inventory.GetAmount(item) >= amt;
    }

    public bool HasItem(Item[] items, int[] amts)
    {
        for (int i = 0; i < items.Length; i++)
            if (!HasItem(items[i], amts[i]))
                return false;
        return true;
    }

    public void RemoveItem(Item item)
    {
        _inventory.RemoveItem(item, 1);
    }

    public void RemoveItem(Item item, int amt)
    {
        _inventory.RemoveItem(item, (byte)amt);
    }
    
    public void RemoveItem(Item[] items, int[] amts)
    {
        for (int i = 0; i < items.Length; i++)
            RemoveItem(items[i], amts[i]);
    }

    public byte GetCapacity()
    {
        return _inventory.GetCapacity();
    }

    public Item[] GetItems()
    {
        return _inventory.GetItems();
    }

    public byte[] GetAmounts()
    {
        return _inventory.GetAmounts();
    }
}
