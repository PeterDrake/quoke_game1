using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using MoreMountains.FeedbacksForThirdParty;
using MoreMountains.InventoryEngine;
using Unity.UNetWeaver;
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
    private BoxCollider fallCollider;

    [Header("Time it takes to trigger the earthquake after the bookcase is secured")]
    public float TriggerTime = 5f;
    
    private void Start()
    {
        _interact = GetComponent<InteractWithObject>();
        _inventory = GameObject.FindWithTag("MainInventory").GetComponent<Inventory>();
        if (CheckItem == null) Debug.LogError("No item to check has been specified");
        rb = GetComponent<Rigidbody>();
        
        fallCollider = transform.Find("Fall Collider").GetComponent<BoxCollider>(); 
        fallCollider.gameObject.GetComponent<CollisionCallback>().AddCallback("Player", HitPlayer);
        fallCollider.enabled = false;

        QuakeManager.Instance.OnQuake.AddListener(Fall);
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
                foreach (var item in _inventory.Content)
                {
                    Debug.Log(item+"| ");
                }
                Debug.Log(_inventory.name);
                _interact.BlinkWhenPlayerNear = false;
                _interact.SetInteractText(NO_TOOLS);
            }

            count++;
            Debug.Log(count);
        }
        else
            QuakeManager.Instance.TriggerQuake();

    }

    public void Interaction()
    {
        if (!isFalling && PlayerHasItem)
        {
            ObjectiveManager.Instance.Satisfy("BOOKCASE");
            _inventory.RemoveItem(Array.FindIndex(_inventory.Content, row => row.ItemID == CheckItem.ItemID), 1);
            QuakeManager.Instance.TriggerCountdown(TriggerTime);
            Disable();
        }
    }
    

    private void Fall()
    {
        if (isFalling) return;
        isFalling = true;
        
        fallCollider.enabled = true;
        rb.isKinematic = false;
        rb.AddRelativeTorque(new Vector3(1,0,0) * FallThrust,ForceMode.VelocityChange);
    }


    private void Disable()
    {
        Destroy(rb);
        Destroy(fallCollider.gameObject.GetComponent<CollisionCallback>());
        Destroy(GetComponent<BoxCollider>());
        Destroy(this);
    }


    private void HitPlayer()
    {
        if (!isFalling) return;
        if (rb.velocity.magnitude <= 0) Disable();
        else
        {
            Debug.Log("Player Hit");
            Death.Manager.PlayerDeath("Your bookcase crushed you :(");            
        }
        
    }





}
