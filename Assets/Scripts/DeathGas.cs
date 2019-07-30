using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MoreMountains.InventoryEngine;
using UnityEngine;
using UnityEngine.UI;

public class DeathGas : MonoBehaviour
{
    public Slider health;

    public Inventory main;
    public GameObject gas;
    public Material mat;
    public GameObject EventTracker;
    public GameObject win;
    public Text death;
    private bool gasOff = false;

    // Start is called before the first frame update
    
    /*
     * initialize the length of the inventory
     */
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
     * After the EarthQuake, checks to see if the player has collided with the gas
     * If they have the wrench in their inventory, the gas is turned off
     * Otherwise, the player dies
     */
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown("e"))
            {
                if (EventTracker.GetComponent<MyEventTracker>().my_CheckInventory("Wrench"))
                {
                    gas.GetComponent<BlinkingObject>().my_blink = mat;
                    win.SetActive(true);
                    gasOff = true;
                    
                }
                
            }

        }

        
        
    }
}
