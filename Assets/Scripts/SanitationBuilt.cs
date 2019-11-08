using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.FeedbacksForThirdParty;
using MoreMountains.InventoryEngine;
using UnityEngine.SceneManagement;
 
public class SanitationBuilt : MonoBehaviour
{
     
    private InteractWithObject _interact;
    private InventoryHelper _inventory;
 
    private BaseItem Bucket;
    private BaseItem Bag;
    private BaseItem Sawdust;
    private BaseItem Sanitizer;
 
    private bool HasSanitizer;
    private bool HasBuckets;
    private bool HasBag;
    private bool HasSawdust;

    private byte Conditions;
    
     
    void Start()
    {
        _interact = GetComponent<InteractWithObject>();
        _inventory = GameObject.FindWithTag("MainInventory").GetComponent<InventoryHelper>();
         
        Bucket =  Resources.Load<BaseItem>("Items/Bucket");
        Bag =  Resources.Load<BaseItem>("Items/Bag");
        Sawdust =  Resources.Load<BaseItem>("Items/Sawdust");
        Sanitizer =  Resources.Load<BaseItem>("Items/Sanitizer");
        _inventory.CheckOnAdd.AddListener(UpdateConditions);
        
        
    }
    
    public void Interaction()
    {
        if ((Conditions^0xF) == 0)
        {
            Debug.Log("Toilet Time!");
            SceneManager.LoadScene("MiniGame", LoadSceneMode.Single);
        }
        else
        {
            _interact.SetInteractText("You need to gather more items");
        }
    }

    private void UpdateConditions() //called every time an item is added to the inventory 
    {
        if ((Conditions ^ 0xF) == 0) return;
        
        if ((Conditions & 0x1) == 0 && _inventory.HasItem(Bucket, 2)) //first condition not met
            Conditions &= 0x1;
        
        if ((Conditions & 0x2) == 0 && _inventory.HasItem(Bag, 1)) //second condition not met
            Conditions &= 0x1;
        
        if ((Conditions & 0x8) == 0 && _inventory.HasItem(Sawdust, 1)) //third condition not met
            Conditions &= 0x1;
        
        if ((Conditions & 0x1) == 0 && _inventory.HasItem(Sanitizer, 1)) //fourth condition not met
            Conditions &= 0x1;
    }
}
