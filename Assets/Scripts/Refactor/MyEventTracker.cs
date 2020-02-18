using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using MoreMountains.InventoryEngine;
using MoreMountains.TopDownEngine;
using UnityEngine.Experimental.PlayerLoop;
using UnityEngine.SceneManagement;

public class MyEventTracker : MonoBehaviour
{
    public InventoryHelper _inventoryHelper;
    public Inventory mainInventory;
    private InventorySlot my_slot;
    private int itemIndex;
    
    //temp
    public GameObject CleanWaterButton;
    public GameObject DrinkWaterButton;
    
    private bool notActivated;
    
    private int bleachCount;
    
    public BaseItem[] RequiredItems;
    private bool[] ItemObtained;
    public BaseItem[] ToAdd;
    private bool activated;
    
    private bool HasAllRequirements;
    private void Start()
    {
        ItemObtained = new bool[RequiredItems.Length];
        _inventoryHelper.CheckOnAdd.AddListener(checkConditions);
        bleachCount = 0;
    }

    public void CleanWater()
    {
        if (bleachCount < 5) {
            //_inventoryHelper.RemoveItem(ToAdd[bleachCount], 1);
            bleachCount++;
            Debug.Log("bcoubnt" + bleachCount + ToAdd[bleachCount]);
            //_inventoryHelper.AddItem(ToAdd[bleachCount], 1);  //currently doesn't add item...??'
        }
        
        activated = true;
    }

    public void DrinkWater()
    {
        //_inventoryHelper.RemoveItem(ToAdd[bleachCount]);
        if (bleachCount > 1 && bleachCount < 5)
        {
            StatusManager.Manager.AffectHydration(100);
        } else if (bleachCount < 2)
        {
            Death.Manager.PlayerDeath(
                "You drank dirty water and died of dysentary. You need to sanitize your water with more bleach");
        }
        else
        {
            Death.Manager.PlayerDeath("You died of bleach poisoning.  You should add less bleach to sanitize your water next time.");
        }
        DrinkWaterButton.SetActive(false);
        CleanWaterButton.SetActive(false);
    }
    

    private void checkConditions()
    {
        if (activated) return;

        for (int i = 0; i < RequiredItems.Length; i++)
        {
            //if (!_inventoryHelper.HasItem(RequiredItems[i], 1)) return;
            
        }
//        CleanWaterButton.SetActive(true);
    }

    public bool my_CheckInventory(string my_itemname)
    {
        if (mainInventory.GetQuantity(my_itemname) != 0)
        {
            return true;
        }
        else return false;
    }
    
}
