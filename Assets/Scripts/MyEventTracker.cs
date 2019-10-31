using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using MoreMountains.InventoryEngine;
using MoreMountains.TopDownEngine;
using UnityEngine.SceneManagement;

public class MyEventTracker : MonoBehaviour
{
    public Inventory mainInventory;
    public InventorySlot my_slot;
    public int itemIndex;
    
    public bool my_CheckInventory(string my_itemname)
    {
        if (mainInventory.GetQuantity(my_itemname) != 0)
        {
           // Debug.Log(my_itemname);
           // how to access this list well?? 
           // Debug.Log(my_itemname.ToString());
           // Debug.Log(mainInventory.GetQuantity("Axe"));
           // Debug.Log(mainInventory.GetQuantity(my_itemname.ToString()));
            return true;
        }
        else return false;
    }

    //Get the inventory slot of an item
    public int my_InventorySlotIndex(string my_itemname)
    {
        for (int i = 0; i < mainInventory.NumberOfFilledSlots; i++)
        {
            if (String.Compare(my_itemname,mainInventory.Content[i].name)==0)
            {
                itemIndex = i;
            }
        }
        return itemIndex;
    }

    public InventorySlot my_InventorySlot()
    {
        for (int i = 0; i < mainInventory.NumberOfFilledSlots; i++)
        {
            
        }
        
        return my_slot;
    }
    public void my_NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
    
    
    
    ////other functions we will need? 
    
    ///Change an NPC to newHead..? 
    
    
}
