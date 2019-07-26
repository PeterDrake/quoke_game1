using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using MoreMountains.InventoryEngine;
using UnityEngine;
using UnityEngine.UI;

public class WaterQuest : MonoBehaviour
{
    public GameObject mainInventory;
    public Slider water;
    public GameObject objective;
    public GameObject eventTracker;
    public GameObject inventoryCanvas;
    public GameObject purifyButton;
    private bool purified;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    { 
        Button();
        Remove();
        
    }

    public void Button()
    {
        for (int i = 0; i < mainInventory.GetComponent<Inventory>().NumberOfFilledSlots; i++)
        {
            if (eventTracker.GetComponent<MyEventTracker>().my_CheckInventory("Water"))
            {
                if (eventTracker.GetComponent<MyEventTracker>().my_CheckInventory("Iodine"))
                {
                    purifyButton.SetActive(true);
                }
            }
        }
    }

    public void MakeWater()
    {
        for (int i = 0; i < mainInventory.GetComponent<Inventory>().NumberOfFilledSlots; i++)
        {
            if (eventTracker.GetComponent<MyEventTracker>().my_CheckInventory("Water"))
            {
                if (eventTracker.GetComponent<MyEventTracker>().my_CheckInventory("Iodine"))
                {
                    water.GetComponent<WaterBar>().waterValue = 100;
                    water.GetComponent<WaterBar>().rate = 0;
                    String waterText = "Accomplished";
                    objective.GetComponent<UpdateQuests>().updateWater(waterText);
                    purified = true;
                }
            }
        }

    }
 
    public void Remove(){
        
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
            purified = false;
        }
    }
        
}
