using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using MoreMountains.InventoryEngine;
using UnityEngine;

public class Bookcase : MonoBehaviour
{
    [Header("Will check for this item to repair bookshelf")]
    public BaseItem CheckItem;
    
    public const string NO_TOOLS = "This bookcase could fall over in an earthquake. I should secure it to the wall.";
    public const string HAS_TOOLS = "Press 'e' to secure the bookshelf";
    
    [Header("The bookcase will fall on the player the (kill_count)th time the player enters the collider")]
    public int KillCount = 4;
    public float FallThrust;
    
    
    private int count = 0;
    
    private InteractWithObject _interact;
    private Inventory _inventory;

    private bool PlayerHasItem = false;
    
    private Rigidbody rb;
    private bool isEnabled = false;
    
    private void Start()
    {
        _interact = GetComponent<InteractWithObject>();
        _inventory = GameObject.FindWithTag("MainInventory").GetComponent<Inventory>();
        if (CheckItem == null) Debug.LogError("No item to check has been specified");
        
        rb = GetComponent<Rigidbody>();
    }
    public void UpdateState()
    {
        if (!isEnabled)
            if (count < KillCount)
            {
                if (PlayerHasItem || _inventory.InventoryContains(CheckItem.name).Count > 0)
                {
                    _interact.BlinkWhenPlayerNear = true;
                    _interact.SetInteractText(HAS_TOOLS);
                    PlayerHasItem = true;
                }

                else
                {
                    _interact.BlinkWhenPlayerNear = false;
                    _interact.SetInteractText(NO_TOOLS);
                }

                count++;
            }
            else
                Fall();
        else
        {
            Debug.Log("Player Hit");
            Death.Manager.PlayerDeath("Your bookcase crushed you to death! :(");
        }

    }

    public void Interaction()
    {
        if (PlayerHasItem)
        {
            _inventory.RemoveItem(Array.FindIndex(_inventory.Content, row => row.ItemID == CheckItem.ItemID),1);
            Disable();
        }
    }
    

    private void Fall()
    {
        GetComponent<BoxCollider>().size = new Vector3(1.5f,1.5f,1.5f);
        rb.isKinematic = false;
        isEnabled = true;
        rb.AddRelativeForce(Vector3.forward * FallThrust);
    }

    private void Disable()
    {
        Destroy(rb);
        Destroy(GetComponent<BoxCollider>());
        Destroy(this);
    }
    





}
