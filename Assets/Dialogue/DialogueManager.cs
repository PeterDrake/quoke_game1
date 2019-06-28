﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.InventoryEngine;

public class DialogueManager : MonoBehaviour

{
    public Canvas dialogueDisplay;

    public Dialogue active;

    public Dialogue responseNodeOne;

    public Dialogue responseNodeTwo;

    public GameObject dialogueEnabler;

    public Dialogue newHead;

   // public InventoryItem my_itemToAdd;
   // public InventoryItem my_hasItem;
    
    public InventoryItem my_itemToAddNode1;
    public InventoryItem my_hasItemNode1;
    public InventoryItem my_itemToAddNode2;
    public InventoryItem my_hasItemNode2;
    
    public Inventory my_targetInventory;

    public GameObject eventTracker;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Initiate());

    }

    IEnumerator Initiate()
    {
        yield return new WaitForEndOfFrame();
        Refresh();
        
    }

    public void Refresh()
    {

        active = dialogueDisplay.GetComponent<DialogueDisplay>().dialogue;
        // Debug.Log(active);
        responseNodeOne = dialogueDisplay.GetComponent<DialogueDisplay>().nextNodeOne; 
        responseNodeTwo = dialogueDisplay.GetComponent<DialogueDisplay>().nextNodeTwo;
        my_itemToAddNode1 = dialogueDisplay.GetComponent<DialogueDisplay>().itemToReceiveNode1;
        my_hasItemNode1 = dialogueDisplay.GetComponent<DialogueDisplay>().hasItemNode1;
        my_itemToAddNode2 = dialogueDisplay.GetComponent<DialogueDisplay>().itemToReceiveNode2;
        my_hasItemNode2 = dialogueDisplay.GetComponent<DialogueDisplay>().hasItemNode2;
        

    }

    public void NextNodeR1()
    {
        // button click should change the active node to the next node... 
        if (responseNodeOne != null){
            //this is always true despite the player not having the item???
                
            if (my_hasItemNode1 == null || eventTracker.GetComponent<MyEventTracker>().my_CheckInventory(my_hasItemNode1.name))
            {
                my_AddItem(my_itemToAddNode1);
                active = responseNodeOne; /// this isn't actually changing the active?
                dialogueDisplay.GetComponent<DialogueDisplay>().dialogue = active;
                dialogueDisplay.GetComponent<DialogueDisplay>().my_update();
                Refresh();
            }
        }
        else
        {
            Deactivate();
        }
    }
    
    public void NextNodeR2()
    {
        // button click should change the active node to the next node
        if (responseNodeTwo != null)
        {
           if (my_hasItemNode2 == null || eventTracker.GetComponent<MyEventTracker>().my_CheckInventory(my_hasItemNode2.name))

           {
               my_AddItem(my_itemToAddNode2);
               active = responseNodeTwo;
               dialogueDisplay.GetComponent<DialogueDisplay>().dialogue = active;
               dialogueDisplay.GetComponent<DialogueDisplay>().my_update();
               Refresh();
           }
        }
        else
        {
           Deactivate();
        }
    }
    
    public void NewHead ()
    {
        dialogueDisplay.GetComponent<DialogueDisplay>().dialogue = newHead;
        dialogueDisplay.GetComponent<DialogueDisplay>().my_update();
        Refresh();
    }

    public void Deactivate()
    {
        //my_AddItem(); // just here temporarily for testing 
      //  NewHead();
        dialogueEnabler.SetActive(false);
    }

    public void my_AddItem(InventoryItem my_itemToAdd)
    {
      //  my_itemToAdd = dialogueDisplay.GetComponent<DialogueDisplay>().itemToReceive;
        my_targetInventory.AddItem(my_itemToAdd, 1);
    }
    
}
