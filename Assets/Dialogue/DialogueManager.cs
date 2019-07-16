using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.InventoryEngine;
using MoreMountains.TopDownEngine;
using UnityEngine.UI;

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
    public InventoryItem my_losesNode1;
    public InventoryItem my_losesNode2;
    
    public Inventory my_targetInventory;

    public GameObject eventTracker;

    public GameObject Node1InvalidEnabler;
    public Text node1InvalidText;
    
    public GameObject Node2InvalidEnabler;
    public Text node2InvalidText;

    public GameObject myPlayer;
    public GameObject myGameManager; 

    private int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Initiate());
        myPlayer = GameObject.FindWithTag("Player");


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
        my_losesNode1 = dialogueDisplay.GetComponent<DialogueDisplay>().PlayerLosesNode1;
        my_losesNode2 = dialogueDisplay.GetComponent<DialogueDisplay>().PlayerLosesNode2;



    }

    public IEnumerator CloseInvalidN1()
    {
        yield return new WaitForSeconds(3f);
        Node1InvalidEnabler.SetActive(false);
    }

    public IEnumerator CloseInvalidN2()
    {
        yield return new WaitForSeconds(3f);
        Node2InvalidEnabler.SetActive(false);

    }
    
    public void NextNodeR1()
    {
        // button click should change the active node to the next node... 

        if (my_hasItemNode1 == null || eventTracker.GetComponent<MyEventTracker>().my_CheckInventory(my_hasItemNode1.name))
        {
                if (my_losesNode1 != null){my_LoseItem(my_losesNode1); }                
                if (my_itemToAddNode1 != null){my_AddItem(my_itemToAddNode1);}

                if (responseNodeOne != null)
                {

                    active = responseNodeOne;
                    dialogueDisplay.GetComponent<DialogueDisplay>().dialogue = active;
                    dialogueDisplay.GetComponent<DialogueDisplay>().my_update();
                    Refresh();
                }
                else
                {
                    Deactivate();
                }
        }
        else
        {
            Node1InvalidEnabler.SetActive(true);
            node1InvalidText.text = "you are missing required " + my_hasItemNode1.name + "!";
           // Debug.Log("you don't have" +  my_hasItemNode1.name);
            StartCoroutine(CloseInvalidN1());
        }
       
    }
    
    public void NextNodeR2()
    {


        if (my_hasItemNode2 == null || eventTracker.GetComponent<MyEventTracker>().my_CheckInventory(my_hasItemNode2.name)) 
        {
               if (my_losesNode2 != null){my_LoseItem(my_losesNode2); }
               if (my_itemToAddNode2 != null){my_AddItem(my_itemToAddNode2); }

               if (responseNodeTwo != null)
               {
                   active = responseNodeTwo;
                   dialogueDisplay.GetComponent<DialogueDisplay>().dialogue = active;
                   dialogueDisplay.GetComponent<DialogueDisplay>().my_update();
                   Refresh();
               }
               else
               {
                   Deactivate();
               }
        }
        else
        {
            Node2InvalidEnabler.SetActive(true);
            node2InvalidText.text = "you are missing required " + my_hasItemNode2.name + "!";
            //Debug.Log("you don't have" +  my_hasItemNode2.name);
            StartCoroutine(CloseInvalidN2());
        }
        
        
    }
    
    public void NewHead ()
    {
        if (newHead != null)
        {
            dialogueDisplay.GetComponent<DialogueDisplay>().dialogue = newHead;
            dialogueDisplay.GetComponent<DialogueDisplay>().my_update();
            Refresh();
        }
    }

    public void Deactivate()
    {
        //my_AddItem(); // just here temporarily for testing 
      //  NewHead();
        myPlayer.GetComponent<CharacterPause>().UnPauseCharacter();
        dialogueEnabler.SetActive(false);
        myGameManager.GetComponent<GameManager>().Pause();
    }

    public void my_AddItem(InventoryItem my_itemToAdd)
    {
      //  my_itemToAdd = dialogueDisplay.GetComponent<DialogueDisplay>().itemToReceive;
        my_targetInventory.AddItem(my_itemToAdd, 1);
    }

    public void my_LoseItem(InventoryItem my_lostItem)
    {
        while (true)
        {
            if (my_targetInventory.Content[i].ItemName == my_lostItem.ItemName)
            {
                my_targetInventory.RemoveItem(i, 1); 
                break;
            }

            i++;
            Debug.Log(i);

        }

    }
    
}
