using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using MoreMountains.InventoryEngine;
using UnityEngine;
using UnityEngine.UI;


public class WaterQuest : MonoBehaviour
{
    public Slider water;
    public GameObject mainInventory;
    public GameObject objective;
    public GameObject eventTracker;
    public GameObject inventoryCanvas;
    public GameObject purifyButton;
    public GameObject iodine;
    public GameObject infoEnabler;
    public String text1;
    public Material mat;
    
    private bool purified;

    // Start is called before the first frame update
    void Start()
    {
    }

    /*
     * call the button method that brings the purify button to life,
     * the remove method which clears the inventory of the items used
     *
     * if the water level reaches 50,
     * give the hint to find water and make the iodine blink;
     *  
     */
    void Update()
    { 
        ButtonOn();
        Remove();

        if (water.GetComponent<WaterBar>().waterValue <=50)
        {
            infoEnabler.SetActive(true);
            eventTracker.GetComponent<InformationCanvas>().DisplayInfo(text1);
            iodine.GetComponent<BlinkingObject>().my_blink = mat;
        }
    }

    /*
     * go through the inventory
     * if there is water in the inventory, make the iodine blink;
     * if there is water and iodine in the inventory ensure, enable the purify button
     * 
     */
    public void ButtonOn()
    {
        for (int i = 0; i < mainInventory.GetComponent<Inventory>().NumberOfFilledSlots; i++)
        {
            if (eventTracker.GetComponent<MyEventTracker>().my_CheckInventory("Water"))
            {
                iodine.GetComponent<BlinkingObject>().my_blink = mat;
                
                if (eventTracker.GetComponent<MyEventTracker>().my_CheckInventory("Iodine"))
                {
                    purifyButton.SetActive(true);
                }
            }
        }
    }

    /*
     * If the button is pressed,
     * increase the water level to 100,
     * the depletion rate to 0;
     * change the text in the water quest to accomplished
     * and the color of the water icon to green
     */
    public void MakeWater()
    {
        
        water.GetComponent<WaterBar>().waterValue = 100; 
        water.GetComponent<WaterBar>().rate = 0;
        String waterText = "Accomplished";
        objective.GetComponent<UpdateQuests>().updateWater(waterText);
        purified = true;
        
    }
 
    /*
     * remove the water and iodine from the inventory
     * and move the items to left by to fill the slots
     * remove the purify button
     * 
     */
    public void Remove()
    {
        if (purified)
        {
            for (int i = 0; i < mainInventory.GetComponent<Inventory>().NumberOfFilledSlots; i++)
            {
                if (mainInventory.GetComponent<Inventory>().Content[i] != null)
                {

                    if (string.Compare(mainInventory.GetComponent<Inventory>().Content[i].name, "Water") == 0)
                    {
                        inventoryCanvas.GetComponent<UseItems>().Re_Move(i);
                    }

                    if (string.Compare(mainInventory.GetComponent<Inventory>().Content[i].name, "Iodine") == 0)
                    {
                        inventoryCanvas.GetComponent<UseItems>().Re_Move(i);
                    }
                }
            }
            
            purifyButton.SetActive(false);
        }
    }
        
}
