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
    
    public GameObject myDialogueManager;
    public BaseItem[] RequiredItems;
    private bool[] ItemObtained;
    public BaseItem[] ToAdd;
    private bool activated;

    public BaseItem Water;
    private bool HasAllRequirements;
    private void Start()
    {
        ItemObtained = new bool[RequiredItems.Length];
        _inventoryHelper.CheckOnAdd.AddListener(checkConditions);
    }

    public void CleanWater()
    {
        foreach (var item in RequiredItems)
        {
            _inventoryHelper.RemoveItem(item, 1);
        }
        
        foreach (var item in ToAdd)
        {
            _inventoryHelper.AddItem(item, 1);
        }
        
        activated = true;
        CleanWaterButton.SetActive(false);
        DrinkWaterButton.SetActive(true);
    }

    public void DrinkWater()
    {
        _inventoryHelper.RemoveItem(Water);
        StatusManager.Manager.AffectHydration(100);
        DrinkWaterButton.SetActive(false);
    }
    

    private void checkConditions()
    {
        if (activated) return;
        
        for (int i = 0; i < RequiredItems.Length; i++)
        {
            if (!_inventoryHelper.HasItem(RequiredItems[i], 1)) return;
            
        }
        
        CleanWaterButton.SetActive(true);
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
