using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using MoreMountains.InventoryEngine;
//using NUnit.Framework.Internal.Commands;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

/** A script to use the items
 *
 *water to increase the hydration levels
 * the sanitation pamphlet to allow the use of buckets (?)
 * Food to feed the person (?), do we have eating levels?
 * Secure bookshelf to add bolts to it
 * *
 */
public class UseItems : MonoBehaviour
{
    public Slider water;
    public GameObject gas;
    public Inventory mainInventory;
    public GameObject buckets;
    public GameObject inventoryDisplay;
    public GameObject waterQuest;
    public GameObject Sanitation;

    public List<GameObject> inventorySlots;
    public Text selected;

    private InventorySlot selectedSlot;
    private int selectedIndex;
    private InventoryItem selectedItem;
    private InventoryItem item;
    private InventoryItem nextItem;
    private InventorySlot inventorySlot;
    
    private int index;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<InventoryInputManager>().CurrentlySelectedInventorySlot != null)
        {
            selectedSlot = GetComponent<InventoryInputManager>().CurrentlySelectedInventorySlot;
            selectedIndex = selectedSlot.Index;
            selectedItem = selectedSlot.ParentInventoryDisplay.TargetInventory.Content[selectedIndex];
            selected.GetComponent<Text>().text = selectedItem.name;
        }
        else
        {
            selected.GetComponent<Text>().text = null;
        }
    }
    
    /**
     *
     * Use the item as specified depending on what it is and then
     * Remove it from the inventory and move the subsequent ones into the removed item's place
     * If it is water,
     *     increase the watervalue to 100 and keep it there
     *     show that the water quest is accomplished,
     * If it is hte sanitation pamphlet, begin the sanitation pursue quests
     * 
     */
    
    
    public void Use()
    { 
        inventorySlot = GetComponent<InventoryInputManager>().CurrentlySelectedInventorySlot;
        index = inventorySlot.Index;
        item = inventorySlot.ParentInventoryDisplay.TargetInventory.Content[index];
        if (String.Compare(item.name, "Water")==0)
        {
            Debug.Log("Water level increased");
            water.GetComponent<WaterBar>().waterValue = 100;
            water.GetComponent<WaterBar>().rate = 0;
            String waterText = "Accomplished";
            waterQuest.GetComponent<UpdateQuests>().updateWater(waterText);
        }

        else if (string.Compare(item.name, "Sanitation Pamphlet") == 0)
        {
            Sanitation.GetComponent<SanitationCheck>().PamphletUsed();
        }
        
        mainInventory.GetComponent<Inventory>().RemoveItem(index, 1);
        for (int i = index; i < mainInventory.NumberOfFilledSlots; i++)
        {
            mainInventory.MoveItem(i + 1, i);
//                inventorySlot.ParentInventoryDisplay.TargetInventory.Content[index+1].
        }
    }
}
