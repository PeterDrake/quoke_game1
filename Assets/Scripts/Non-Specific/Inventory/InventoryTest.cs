using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryTest : MonoBehaviour
{
    private byte capacity;
    private byte heldAmount;
    private Item[] items;
    private byte[] amounts;

    private void Awake()
    {
        amounts = new byte[capacity];
        for (int i = 0; i < capacity; i+=1)
        {
            amounts[i] = 0;
        }
        
        items = new Item[capacity];
    }

    public bool AddItem(Item i, byte amt)
    {
        int k = HasItem(i,1);
        if (k != -1)
        {
            amounts[k] += amt;
        }
        else if (heldAmount == capacity)
        {
            return false;
        }
        else
        {
            k = 0;
            while (amounts[k] != 0) k+=1;
            items[k] = i;
            amounts[k] = amt;
        }

        return true;
    }

    public int HasItem(Item i, int amt)
    {
        for (int j = 0; j < capacity; j+=1)
            if (i.ID == items[j].ID && this.amounts[j] >= amt) return j;
        
        return -1;
    }

    public byte GetAmount(Item i)
    {
        int k = HasItem(i,1);
        if (k != -1) return amounts[k];
        
        return 0;
    }

    public Item RemoveItem(Item i, byte amt)
    {
        int k = HasItem(i, amt);
        if (k != -1)
        {
            amounts[k] -= amt;
            if (amounts[k] <= 0)
            {
                amounts[k] = 0;
                items[k] = null;
            }
        }

        return i;
    }
    
    public Item RemoveAll(Item i)
    {
        return RemoveItem(i, GetAmount(i));
    }
        
    public byte GetCapacity()
    {
        return capacity;
    }

}
