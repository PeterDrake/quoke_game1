using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using MoreMountains.InventoryEngine;
//using NUnit.Framework.Internal.Commands;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UseItems : MonoBehaviour
{
    public GameObject mainInventory;
    public Slider water;

    private InventoryItem item;
    private InventorySlot inventorySlot;
    private int index;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void Drink()
    { 
        inventorySlot = GetComponent<InventoryInputManager>().CurrentlySelectedInventorySlot;
        index = inventorySlot.Index;
        item = inventorySlot.ParentInventoryDisplay.TargetInventory.Content[index];
        if (String.Compare(item.name, "Water")==0)
        {
            Debug.Log("Water level increased");
            water.GetComponent<WaterBar>().waterValue = 100;
        }
    }

}
