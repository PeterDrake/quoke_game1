using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.InventoryEngine;
using UnityEngine.Events;

public class InteractWithObject : MonoBehaviour
{
    //-----Material Blinking-------
    public bool BlinkWhenPlayerNear = true;
    private Material mat_original;
    private Material mat_blink;
    private MeshRenderer _meshRenderer;
    private float timer = 0;
    private bool blinkOn = false;
    private bool playerInCollider = false;
    //-----------------------------
    
    //-----Item Manipulation------
    public BaseItem itemToReceive;
    private Inventory inventory;
    //---------------------------
    
    //-----Interaction Text-----
    public string InteractionDisplayText;
    public InteractText interactText;
    //---------------------------
    
    //------Event Methods--------
    [Header("Called when Player presses Interact Button (likely 'e')")]
    public UnityEvent CallOnInteract;
    [Header("Called when Player enters the trigger collider on this object")]
    public UnityEvent CallOnEnterCollider;
    //----------------------------
    
    
    public bool killAfterUse = true;
    private byte interactionDelayFrames = 0;
    private byte interactionDelayFramesMax = 60;

    public void Start()
    {
        // get reference for inventory manipulation   
        inventory = GameObject.FindWithTag("MainInventory").GetComponent<Inventory>();
        
    // materials for material blinking
        mat_original = gameObject.GetComponent<MeshRenderer>().material;
        mat_blink = Resources.Load("Transparent Object 1", typeof(Material)) as Material;
        _meshRenderer = GetComponent<MeshRenderer>();
    }
    
    public void FixedUpdate()
    {
        if (playerInCollider)
        {
            timer += Time.deltaTime;
            if (timer > .6)
            {
                timer = 0;
                if (blinkOn)
                {
                    _meshRenderer.material = mat_original;
                    blinkOn = false;
                }
                else
                {
                    _meshRenderer.material = mat_blink;
                    blinkOn = true;
                }
            }
        }
    }

    public void Update()
    {
        if (interactionDelayFrames <= 0 && playerInCollider && Input.GetAxis("Interact") > 0)
        {
            interactionDelayFrames = interactionDelayFramesMax;
            if (itemToReceive != null)
            {
                inventory.AddItem(itemToReceive,1);
                itemToReceive = null;
            }
            CallOnInteract.Invoke();
            interactText.ToggleVisibility(false);
            if (killAfterUse)
            {
                _meshRenderer.material = mat_original;
                Destroy(this);
            }
        }
        else if (interactionDelayFrames > 0)
        {
            interactionDelayFrames--;    
        }
        
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Player"))
        {
            CallOnEnterCollider.Invoke();
            interactText.ChangeText(InteractionDisplayText);
            playerInCollider = true;
        }
    }
    
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactText.ToggleVisibility(false);
            playerInCollider = false;
            _meshRenderer.material = mat_original;
 
        }
    }
}
