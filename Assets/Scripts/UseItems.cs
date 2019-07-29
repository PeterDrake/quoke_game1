using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using MoreMountains.InventoryEngine;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR.WSA.WebCam;
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
    
    /**
     *
     * Use the item as specified depending on what it is and then
     * Remove it from the inventory and move the subsequent ones into the removed item's place
     * If it is water, kill the person as it is not purified
     * If it is hte sanitation pamphlet, begin the sanitation pursue quests
     * 
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
           // Sanitation.GetComponent<SanitationCheck>().Collection();
        }
        
        Re_Move(index);
    }
    
    /*
     * Remove the item at the specified index
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
