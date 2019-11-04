using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.FeedbacksForThirdParty;
using MoreMountains.InventoryEngine;

public class ToiletCheck : MonoBehaviour
{
    
    private InteractWithObject _interact;
    private Inventory _inventory;
    private bool PlayerHasItems = false;

    private bool HasSanitizer;
    private bool HasBuckets;
    private bool HasBag;
    private bool HasSawdust;
    private bool ObjectItem;
    
    void Start()
    {
        _interact = GetComponent<InteractWithObject>();
        _inventory = GameObject.FindWithTag("MainInventory").GetComponent<Inventory>();
    }

    public void Interaction()
    {
        if (_inventory.InventoryContains(Sanitizer.name).Count > 0)
        {
            HasSanitizer = true;
        }

        if (_inventory.InventoryContains(Bucket.name).Count > 1)
        {
            HasBuckets = true;
        }

        if (_inventory.InventoryContains(Bag.name).Count > 0)
        {
            HasBag = true;
        }

        if (_inventory.InventoryContains(Sawdust.name).Count > 0)
        {
            HasSawdust = true;
        }

        if (HasBag && HasSanitizer && HasBuckets && HasSawdust)
        {
            _inventory.RemoveItem(Array.FindIndex(_inventory.Content, row => row.ItemID == Sanitizer.ItemID), 1);
        }
    }
}
