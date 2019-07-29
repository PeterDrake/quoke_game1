using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using MoreMountains.InventoryEngine;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

/** A script to use the items
 * It checks the inventory for the selected item, depending on what it is executes series of action
 * Then removes the used item from the inventory
 * 
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
    public GameObject health;
    public GameObject starter;
    
    public List<GameObject> inventorySlots;
    public Text selected;
    public Text deathText;
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
        if (starter.active == false)
        {
            selectedSlot = GetComponent<InventoryInputManager>().CurrentlySelectedInventorySlot;
            selectedIndex = selectedSlot.Index;
            selectedItem = selectedSlot.ParentInventoryDisplay.TargetInventory.Content[selectedIndex];
            if (selectedItem != null)
            {
                selected.GetComponent<Text>().text = selectedItem.name;
            }
            else
            {
                selected.GetComponent<Text>().text = null;
            }
        }
       
    }
    
   /* water is unpurified so you die
    * the sanitation pamphlet allows the collection of everything needed for the twin bucket
    */
    
    public void Use()
    { 
        inventorySlot = GetComponent<InventoryInputManager>().CurrentlySelectedInventorySlot;
        index = inventorySlot.Index;
        item = inventorySlot.ParentInventoryDisplay.TargetInventory.Content[index];
        
        if (String.Compare(item.name, "Water") == 0)
        {
            health.GetComponent<Slider>().value = 0;
            deathText.text = "You drank unpurified water :("; 
            
        }
        
        else if (string.Compare(item.name, "Sanitation Pamphlet") == 0)
        {
            Sanitation.GetComponent<SanitationCheck>().PamphletUsed();
        }
        
        Re_Move(index);
    }
    
    
    /* Remove the item at the specified index
     * and move the items after it into the spots in front of them till there are no more gaps
     */

    public void Re_Move(int inddex)
    {
        mainInventory.GetComponent<Inventory>().RemoveItem(inddex, 1);
        for (int i = inddex; i < mainInventory.NumberOfFilledSlots; i++)
        {
            mainInventory.MoveItem(i + 1, i);
        }
    }
    
}
