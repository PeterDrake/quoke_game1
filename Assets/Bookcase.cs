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
    
    private const string NO_TOOLS = "This bookcase could fall over in an earthquake. I should secure it to the wall.";
    private  const string HAS_TOOLS = "Press 'e' to secure the bookshelf";
    
    [Header("The bookcase will fall on the player the (kill_count)th time the player enters the collider")]
    public int KillCount = 4;
    public float FallThrust;
    
    
    private int count = 0;
    
    private InteractWithObject _interact;
    private Inventory _inventory;

    private bool PlayerHasItem = false;
    
    private Rigidbody rb;
    private bool isFalling = false;

    private void Start()
    {
        _interact = GetComponent<InteractWithObject>();
        _inventory = GameObject.FindWithTag("MainInventory").GetComponent<Inventory>();
        if (CheckItem == null) Debug.LogError("No item to check has been specified");
        
        rb = GetComponent<Rigidbody>();
        
        transform.Find("Fall Collider").GetComponent<CollisionCallback>().AddCallback("Player", HitPlayer);
    }
    public void UpdateState()
    {
        if (isFalling) return;
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
            Debug.Log(count);
        }
        else
        {
            isFalling = true;
            Fall();
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
        if (!isFalling) return;
        
        rb.isKinematic = false;
        rb.AddRelativeTorque(new Vector3(1,0,0) * FallThrust,ForceMode.VelocityChange);
    }

    private void Disable()
    {
        Destroy(rb);
        Destroy(GetComponent<BoxCollider>());
        Destroy(this);
    }


    private void HitPlayer()
    {
        Debug.Log("Player Hit");
        Death.Manager.PlayerDeath("Your bookcase crushed you to death! :(");
    }





}
