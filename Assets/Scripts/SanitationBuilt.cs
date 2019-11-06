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
    private Inventory _inventory;
 
    private BaseItem Bucket;
    private BaseItem Bag;
    private BaseItem Sawdust;
    private BaseItem Sanitizer;
 
    private bool HasSanitizer;
    private bool HasBuckets;
    private bool HasBag;
    private bool HasSawdust;
     
    void Start()
    {
        _interact = GetComponent<InteractWithObject>();
        _inventory = GameObject.FindWithTag("MainInventory").GetComponent<Inventory>();
         
        Bucket =  Resources.Load<BaseItem>("Items/Bucket");
        Bag =  Resources.Load<BaseItem>("Items/Bag");
        Sawdust =  Resources.Load<BaseItem>("Items/Sawdust");
        Sanitizer =  Resources.Load<BaseItem>("Items/Sanitizer");
    }
 
    public void Interaction()
    {
        if (_inventory.InventoryContains(Bucket.name).Count > 1 && _inventory.InventoryContains(Bag.name).Count > 0 && 
            _inventory.InventoryContains(Sawdust.name).Count > 0 && _inventory.InventoryContains(Sanitizer.name).Count > 0)
        {
            Debug.Log("Toilet Time!");
            SceneManager.LoadScene("MiniGame", LoadSceneMode.Single);
        }
        else
        {
            _interact.SetInteractText("You need to gather more items");
        }
    }
}
