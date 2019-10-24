using System.Collections;
using System.Collections.Generic;
using MoreMountains.InventoryEngine;
using UnityEngine;

public class Bookcase : MonoBehaviour
{
    [Header("Will check for this item to repair bookshelf")]
    public BaseItem CheckItem;
    
    public static string NO_TOOLS = "This bookcase could fall over in an earthquake. I should secure it to the wall.";
    public static string HAS_TOOLS = "Press 'e' to secure the bookshelf";
    
    [Header("The bookcase will fall on the player the (kill_count)th time the player enters the collider")]
    public int KillCount = 4;
    private int count = 0;
    
    private InteractWithObject _interact;
    private Inventory _inventory;
    private void Start()
    {
        _interact = GetComponent<InteractWithObject>();
        _inventory = GameObject.FindWithTag("MainInventory").GetComponent<Inventory>();
        if (CheckItem == null) Debug.LogError("No item to check has been specified");
    }
    public void UpdateState()
    {
        if (count < KillCount)
        {
            if (_inventory.InventoryContains(CheckItem.name).Count > 0)
            {
             _interact.interactText =    
            }
            count++;
        }
        else
        {
            Debug.Log("FALLN");
        }
        
    }



}
