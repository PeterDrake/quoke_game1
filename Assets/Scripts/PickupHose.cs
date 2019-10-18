using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.InventoryEngine;

public class PickupHose : MonoBehaviour
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
    public BaseItem itemtoReceive;
    public GameObject interactNotifier;
    private Inventory inventory;
    //---------------------------
    
    //private bool isColliding;
    
    public bool killAfterUse = true;

    public void Start()
    {
        Debug.Log("This script has changed, make sure its ok!" + gameObject.name);
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
        if (playerInCollider && Input.GetAxis("Interact") > 0)
        {
            if (itemtoReceive != null) inventory.AddItem(itemtoReceive,1);

            interactNotifier.SetActive(false);
            if (killAfterUse) Destroy(this);
        }
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Player"))
        {
            playerInCollider = true;
        }
    }

    /*private void OnTriggerStay(Collider other) 
    {
        if (other.CompareTag("Player"))
        {
            if (!isColliding && Input.GetAxis("Interact") > 0)
            {
                isColliding = true;

               
            }
            

        }
    }*/
    
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //isColliding = false;
            playerInCollider = false;
            _meshRenderer.material = mat_original;
 
        }
    }
}
