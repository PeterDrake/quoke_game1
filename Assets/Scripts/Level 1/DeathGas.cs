using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MoreMountains.InventoryEngine;
using UnityEngine;
using UnityEngine.UI;

public class DeathGas : MonoBehaviour
{
    public MoreMountains.InventoryEngine.Inventory main;
    public GameObject gas;
    public Material mat;
    public GameObject EventTracker;
    public GameObject win;
    private bool gasOff = false;
    private MyEventTracker eventTracker;
    
    
    public void Start()
    {
        eventTracker = EventTracker.GetComponent<MyEventTracker>();
    }

    /*
     * After the EarthQuake, checks to see if the player has collided with the gas
     * If they have the wrench in their inventory, the gas is turned off
     * Otherwise, the player dies
     */
    private void OnTriggerStay(Collider other)
    {
        if (!gasOff && other.CompareTag("Player") && Input.GetKeyDown("e") && eventTracker.my_CheckInventory("Wrench"))
        {
            gas.GetComponent<BlinkingObject>().my_blink = mat;
            win.SetActive(true);
            gasOff = true;
        }
    }
}
