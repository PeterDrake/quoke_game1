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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MakeWater()
    {
        for (int i = 0; i < mainInventory.GetComponent<Inventory>().NumberOfFilledSlots; i++)
        {
            if (eventTracker.GetComponent<MyEventTracker>().my_CheckInventory("Water"))
            {
                if (eventTracker.GetComponent<MyEventTracker>().my_CheckInventory("Iodine"))
                {
                     Debug.Log("Water level increased");
                     water.GetComponent<WaterBar>().waterValue = 100;
                     water.GetComponent<WaterBar>().rate = 0;
                     String waterText = "Accomplished";
                     objective.GetComponent<UpdateQuests>().updateWater(waterText);
                }
            }
        }
        
    }
}
