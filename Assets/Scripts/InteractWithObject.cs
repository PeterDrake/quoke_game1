using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.InventoryEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

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
    public BaseItem[] itemToReceive = new BaseItem[1];
    private InventoryHelper inventory;

    private bool hasItem;
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
    
    [Header("'Kill After Use' destroys the script', 'Destroy Object After Use', destroys the whole game object")]
    public bool killAfterUse = true;
    public bool DestoryObjectAfterUse = false;
    private byte interactionDelayFrames = 0;
    private byte interactionDelayFramesMax = 20;

    private void Awake()
    {
        hasItem = (itemToReceive != null);
        if (hasItem && itemToReceive.Length > 0)
        {
            foreach (var item in itemToReceive)
            {
                if (item == null)
                {
                    hasItem = false;
                    Debug.LogWarning(name+"has non-zero item-to-give length, but one of the items is null!");
                    break;
                }
            }
        }
    }


    public void Start()
    {
        if (interactText == null) interactText = GameObject.Find("Canvi").transform.Find("InteractNotifier").GetComponent<InteractText>();
        
        // get reference for inventory manipulation
        if (hasItem) inventory = GameObject.FindWithTag("MainInventory").GetComponent<InventoryHelper>();
        
        
        // materials for material blinking
        mat_original = gameObject.GetComponent<MeshRenderer>().material;
        mat_blink = Resources.Load("Transparent Object 1", typeof(Material)) as Material;
        _meshRenderer = GetComponent<MeshRenderer>();
    }
    
    public void FixedUpdate()
    {
        if (BlinkWhenPlayerNear && playerInCollider)
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
            if (hasItem && itemToReceive != null)
            {
                foreach (var item in itemToReceive)
                    inventory.AddItem(item,1);

                itemToReceive = null;
            }
            CallOnInteract.Invoke();

            if (DestoryObjectAfterUse)
            {
                interactText.ToggleVisibility(false);
                Destroy(gameObject);
            }
            
            if (killAfterUse)
            {
                interactText.ToggleVisibility(false);
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
        if (!playerInCollider && other.CompareTag("Player"))
        {
            CallOnEnterCollider.Invoke();
            
            if (InteractionDisplayText != "") interactText.ChangeText(InteractionDisplayText);
            playerInCollider = true;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (!playerInCollider && other.CompareTag("Player"))
        {
            interactText.ToggleVisibility(true);
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

    public void SetInteractText(string newText)
    {
        this.InteractionDisplayText = newText;
        interactText.ChangeText(InteractionDisplayText);
    }

    public void DeleteItems()
    {
        itemToReceive = null;
        hasItem = false;
    }
}
