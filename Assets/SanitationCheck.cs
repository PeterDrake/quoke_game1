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
    //public GameObject carbon;
    public GameObject deadLeaves;
    public GameObject paper1, paper2, paper3;
    public GameObject deadBranches1, deadBranches2, deadBranches3;
    public GameObject mainInventory;
    public Material mat;
    public Text sanitation;

    private int carbon=0;
    private int plasticBags = 0;
    private int bucketsnumber=0;
    private int sanitizer = 0;
    private string SanitationDone;

    /*
     * If the Sanitation pamphlet is in the inventory, they don't have to go talk to the NET,
     * Otherwise inform them that they should go talk to the NET
     * 
     */
    
    // Start is called before the first frame update
    void Start()
    {
        SanitationDone = "Accomplished";
        Debug.Log("Started");
    }
    
    // Update is called once per frame
    void Update()
    {
        Collection();
        
//        if(!eventTracker.GetComponent<MyEventTracker>().my_CheckInventory("Sanitation Pamphlet"))
//        {
//            sanitation.text = "talk to NET";
//        }
//        

    }
    public void PamphletUsed()
    {
        // Debug.Log("sanitation pamphlet here");
            buckets.GetComponent<BucketsExist>().BucketInventory();
            EnableCarbon();
            sanitation.text = "Find carbon";

    }
    
    private void EnableCarbon()
    {
        deadLeaves.GetComponent<BlinkingObject>().my_blink = mat;
        paper1.GetComponent<BlinkingObject>().my_blink = mat;
        paper2.GetComponent<BlinkingObject>().my_blink = mat;
        paper3.GetComponent<BlinkingObject>().my_blink = mat;
        deadBranches1.GetComponent<BlinkingObject>().my_blink = mat;
        deadBranches2.GetComponent<BlinkingObject>().my_blink = mat;
        deadBranches3.GetComponent<BlinkingObject>().my_blink = mat;
    }


    public void Collection()
    {
        for (int i = 0; i < mainInventory.GetComponent<Inventory>().NumberOfFilledSlots; i++)
        {
            Debug.Log("We are collecting");
            if (mainInventory.GetComponent<Inventory>().Content[i].Prefab)
            {
                if (mainInventory.GetComponent<Inventory>().Content[i].Prefab.CompareTag("Carbon"))
                {
                    carbon++;
                    Debug.Log("One more carbon");
                }
            }
            
            if (string.Compare(mainInventory.GetComponent<Inventory>().Content[i].name, "Bucket")==0)
            {
                bucketsnumber++;
                Debug.Log("One more bucket");

            }
             
            else if(string.Compare(mainInventory.GetComponent<Inventory>().Content[i].name,"Plastic Bags")==0)
            {
                plasticBags++;
                Debug.Log("One plastic bag");

            }
            else if(string.Compare(mainInventory.GetComponent<Inventory>().Content[i].name,"Sanitizer")==0)
            {
                sanitizer++;
                Debug.Log("One Sanitizer");

            }
        }
        
        QuestComplete();
    }

    public void QuestComplete()
    {
        Debug.Log(carbon);
        Debug.Log(bucketsnumber);
        Debug.Log(sanitizer);
        Debug.Log(plasticBags);
        if ((carbon>2)&&(bucketsnumber>2)&&(plasticBags>1)&&(sanitizer>1))
        {
            Debug.Log("You have everything :)");
            
            quests.GetComponent<UpdateQuests>().updateSanitation(SanitationDone);
        }
    }
}
