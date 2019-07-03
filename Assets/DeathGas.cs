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
    public Inventory starter;
    public GameObject gas;
    public Material mat;
    public GameObject EventTracker;
    
    private int mainNum;
    private int starterNum;
    private bool gasOff = false;

    // Start is called before the first frame update
    
    /*initialize the length of the inventory*/
    void Start()
    {
        mainNum = main.GetComponent<Inventory>().Content.Length;
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /* After the EarthQuake, checks to see if the player has collided with the gas
     If they have the wrench in their inventory, the gas is turned off 
     Otherwise, the player dies
     
     */
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (EventTracker.GetComponent<MyEventTracker>().my_CheckInventory("Wrench"))
            {
                gas.GetComponent<BlinkingObject>().my_blink = mat;
                Debug.Log("You have a wrench in your inventory");
                gasOff = true;
                //break;
            }
            /* 
             for (int i = 0; i < mainNum; i++)
             {
                 if (main.GetComponent<Inventory>().Content.ElementAt(i))
                 {
                     // Debug.Log(main.GetComponent<Inventory>().Content.ElementAt(i));
                     if (main.GetComponent<Inventory>().Content.ElementAt(i).Prefab.CompareTag("Wrench"))
                     {
                         gas.GetComponent<BlinkingObject>().my_blink = mat;
                         Debug.Log("You have a wrench in your inventory");
                         gasOff = true;
                         break;
                     }
                 }
 
             }
             
 
             if (gasOff == false)
             {
                 for (int i = 0; i < starterNum; i++)
                 {
                     if (starter.GetComponent<Inventory>().Content.ElementAt(i))
                     {
                         if (starter.GetComponent<Inventory>().Content.ElementAt(i).Prefab.CompareTag("Wrench"))
                         {
                             gas.GetComponent<BlinkingObject>().my_blink = mat;
                             Debug.Log("You have a wrench in your starter inventory");
                             gasOff = true;
                             break;
 
                         }
                     }
 
                 }
             }
             */

            if (gasOff == false)
            {
                {
                    health.GetComponent<Slider>().value = health.GetComponent<Slider>().minValue;
                }
                
            }

        }

        
        
    }
}
