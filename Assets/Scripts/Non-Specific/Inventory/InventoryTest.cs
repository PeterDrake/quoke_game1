using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryTest : MonoBehaviour
{
    private byte capacity;
    private byte[] items;
    private Dictionary<string, byte> containedItems;

    private void Awake()
    {
        containedItems = new Dictionary<string, byte>();
        items = new byte[capacity];
    }

    /*public bool AddItem(Item i, byte amt)
    {
        if (containedItems.ContainsKey(i.ID))
        {
            items[containedItems[i.ID]] += amt;
        }
        else
        {
            
        }
    }

    public bool HasItem(Item i, byte amt)
    {
        
    }

    public byte GetAmount(Item i)
    {
        
    }

    public Item RemoveItem(Item i, byte amt)
    {
        
    }
    
    public Item RemoveAll(Item i)
    {
        
    }
        
    public byte GetCapacity()
    {
        return capacity;
    }*/

}
