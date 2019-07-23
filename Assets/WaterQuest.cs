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

    private bool purified;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Remove();
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
                    purified = true;
                }
            }
        }

        Debug.Log(purified);
    }
 
    public void Remove(){
        if (purified)
        {
            for (int i = 0; i < mainInventory.GetComponent<Inventory>().NumberOfFilledSlots+1; i++)
            {
                if (string.Compare(mainInventory.GetComponent<Inventory>().Content[i].name, "Water")==0)
                {
                    inventoryCanvas.GetComponent<UseItems>().Re_Move(i);
                }
                    
                if (string.Compare(mainInventory.GetComponent<Inventory>().Content[i].name,"Iodine")==0)
                {
                    inventoryCanvas.GetComponent<UseItems>().Re_Move(i);
                }
                    
            }
                
        }
    }
        
}
