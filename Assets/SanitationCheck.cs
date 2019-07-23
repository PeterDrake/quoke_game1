using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using MoreMountains.InventoryEngine;
using MoreMountains.TopDownEngine;
using UnityEngine;
using UnityEngine.UI;

public class SanitationCheck : MonoBehaviour
{
    public GameObject eventTracker;
    public GameObject buckets;
    public GameObject quests;
    public GameObject deadLeaves;
    public GameObject paper1, paper2, paper3;
    public GameObject deadBranches1, deadBranches2, deadBranches3;
    public GameObject plasticBags;
    public GameObject sanitizer;
    public GameObject inventoryCanvas;

    public GameObject mainInventory;
    //public GameObject carbon;
    public bool netTalked = false;
    public Material mat;

    public Text sanitation;
    public Text carbonText;
    public Text bucketsText;
    public Text sanitizerText;
    public Text plasticBagsText;

    private InventoryItem item;
    private int index;
    private int carbon;
    private int plasticBagsnumber;
    private int bucketsnumber;
    private int sanitizerNumber ;
    private string SanitationDone;
    
    private bool spUsed= false;

    /*
     * If the Sanitation pamphlet is in the inventory, they don't have to go talk to the NET,
     * Otherwise inform them that they should go talk to the NET
     * 
     */
    
    // Start is called before the first frame update
    void Start()
    {
        SanitationDone = "Accomplished";
       Debug.Log(mainInventory.GetComponent<Inventory>().Content.Length);
    }
    
    // Update is called once per frame
    
    /*
     * Update what items of the Sanitation have been acquired
     * It will only be activated if the Sanitation Pamphlet has been used
     */
    void Update()
    { 
        Collection();
//        if(!eventTracker.GetComponent<MyEventTracker>().my_CheckInventory("Sanitation Pamphlet"))
//        {
//            sanitation.text = "talk to NET";
//        
    }
    
    /*
     * 
     * Checks if the pamphlet has been used and enables the blinking components for the toilet
     * 
     */
    
    
    public void PamphletUsed()
    {
            buckets.GetComponent<BucketsExist>().BucketInventory();
            EnableObjects();
            sanitation.text = "Find";
            spUsed = true;
    }
    
    public void EnableObjects()
    {
        deadLeaves.GetComponent<BlinkingObject>().my_blink = mat;
        paper1.GetComponent<BlinkingObject>().my_blink = mat;
        paper2.GetComponent<BlinkingObject>().my_blink = mat;
        paper3.GetComponent<BlinkingObject>().my_blink = mat;
        deadBranches1.GetComponent<BlinkingObject>().my_blink = mat;
        deadBranches2.GetComponent<BlinkingObject>().my_blink = mat;
        deadBranches3.GetComponent<BlinkingObject>().my_blink = mat;
        plasticBags.GetComponent<BlinkingObject>().my_blink = mat;
        sanitizer.GetComponent<BlinkingObject>().my_blink = mat;
    }

/*
 * checks what items have been collected and if they are enough
 */
    public void Collection()
    {
         carbon = 0;
         bucketsnumber = 0;
         plasticBagsnumber = 0;
         sanitizerNumber = 0;
         if (spUsed || netTalked)
         {
             for (int i = 0; i < mainInventory.GetComponent<Inventory>().NumberOfFilledSlots; i++)
             {
                 //Debug.Log("We are collecting");

                 if (mainInventory.GetComponent<Inventory>().Content[i].Prefab)
                 {
                     if (mainInventory.GetComponent<Inventory>().Content[i].Prefab.CompareTag("Carbon"))
                     {
                         int button = i;
                         carbon++;
                         Debug.Log("One more carbon");
                     }
                 }

                 if (string.Compare(mainInventory.GetComponent<Inventory>().Content[i].name, "Bucket") == 0)
                 {
                     bucketsnumber++;
                     Debug.Log("One more bucket");
                 }

                 if (string.Compare(mainInventory.GetComponent<Inventory>().Content[i].name, "Plastic Bags") == 0)
                 {
                     plasticBagsnumber++;
                     Debug.Log("One plastic bag");
                 }

                 if (string.Compare(mainInventory.GetComponent<Inventory>().Content[i].name, "Sanitizer") == 0)
                 {
                     sanitizerNumber++;
                     Debug.Log("One Sanitizer");
                 }
             }

             if (carbon>=2)
             {
                 carbonText.color = Color.green;
             }

             if (bucketsnumber>=2)
             {
                 bucketsText.color = Color.green;
             }

             if (plasticBagsnumber>=1)
             {
                 plasticBagsText.color = Color.green;
             }

             if (sanitizerNumber>=1)
             {
                 sanitizerText.color = Color.green;
             }
             
//             QuestComplete();
         }
         
         else
         {
             sanitation.text = "Talk to NPC";
         }
    }

    /*
     * checks if all items have been collected
     * makes the toilet
     * removes the used items from the inventory
     * Updates the quest to completed
     */
    public void QuestComplete()
    {
        Collection();
        Debug.Log("Carbon"+carbon);
        Debug.Log("Buckets"+bucketsnumber);
        Debug.Log("sanitizer"+sanitizer);
        Debug.Log("plastic Bags"+plasticBags);
        
        if ((carbon>=2) &&(bucketsnumber>=2)&&(plasticBagsnumber>=1)&&(sanitizerNumber>=1))
        {
            Debug.Log("You have everything :)");
            quests.GetComponent<UpdateQuests>().updateSanitation(SanitationDone);
            for (int i = 0; i < mainInventory.GetComponent<Inventory>().Content.Length; i++)
            {
                if (string.Compare(mainInventory.GetComponent<Inventory>().Content[i].name, "Bucket")==0)
                {
                     inventoryCanvas.GetComponent<UseItems>().Re_Move(i);
                }
                else if (string.Compare(mainInventory.GetComponent<Inventory>().Content[i].name, "Plastic Bags")==0)
                {
                    inventoryCanvas.GetComponent<UseItems>().Re_Move(i);
                }
                else if (string.Compare(mainInventory.GetComponent<Inventory>().Content[i].name, "Sanitizer")==0)
                {
                    inventoryCanvas.GetComponent<UseItems>().Re_Move(i);
                }
                else if (mainInventory.GetComponent<Inventory>().Content[i].Prefab)
                {
                    if (mainInventory.GetComponent<Inventory>().Content[i].Prefab.CompareTag("Carbon"))
                    {
                        inventoryCanvas.GetComponent<UseItems>().Re_Move(i);
                    }
                }
            }
        }
    }
}
