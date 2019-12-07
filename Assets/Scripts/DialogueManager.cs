using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.InventoryEngine;
using MoreMountains.TopDownEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour

{
    /// <summary>
    /// Handles all of the logic for having a conversation
    /// </summary>
    
    public Canvas dialogueDisplay;

    private Dialogue active;

    private Dialogue responseNodeOne;

    private Dialogue responseNodeTwo;

    public GameObject dialogueEnabler;

    public Dialogue newHead;

    
    private InventoryItem itemToAddNode1;
    private InventoryItem itemToAddNode2;
    
    private InventoryItem hasItemNode1;
    private InventoryItem hasItemNode2;
    
    private InventoryItem losesNode1;
    private InventoryItem losesNode2;
    
    public InventoryHelper _inventoryHelper;

    public GameObject eventTracker;

    public GameObject Node1InvalidEnabler;
    public Text node1InvalidText;
    
    public GameObject Node2InvalidEnabler;
    public Text node2InvalidText;

    private GameObject myPlayer;
    //public GameObject myGameManager;

    public GameObject nodeTwoButton;
    public bool NPCL3;
    
    public bool LevelEvents;
    public levelEvents levelEvents;
    private bool notChecked = true;
    
    public GameObject NPCl3interact;

    private int i = 0;

    private bool DontDoThisTwice;
    // Start is called before the first frame update
    void Start()
    {
        Debug.LogWarning("You may have to change this objects reference to use the InventoryHelper: " + name);
        StartCoroutine(Initiate());
        myPlayer = GameObject.FindWithTag("FakePlayer");
    }

    IEnumerator Initiate()
    {
        yield return new WaitForEndOfFrame();
        Refresh();
        
    }

    public void Refresh()
    {
        var disp = dialogueDisplay.GetComponent<DialogueDisplay>();
        
        nodeTwoButton.SetActive(true);

        active = disp.dialogue;
        
        responseNodeOne = disp.nextNodeOne; 
        responseNodeTwo = disp.nextNodeTwo;
        if (responseNodeTwo == null)
        { 
            nodeTwoButton.SetActive(false);       
        }

        itemToAddNode1 = disp.itemToReceiveNode1;
        hasItemNode1 = disp.hasItemNode1;
        itemToAddNode2 = disp.itemToReceiveNode2;
        hasItemNode2 = disp.hasItemNode2;
        losesNode1 = disp.PlayerLosesNode1;
        losesNode2 = disp.PlayerLosesNode2;
        
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

        if (hasItemNode1 == null || eventTracker.GetComponent<MyEventTracker>().my_CheckInventory(hasItemNode1.name))
        {
            if (losesNode1 != null){_inventoryHelper.RemoveItem((BaseItem)losesNode1); }                
            if (!DontDoThisTwice && ObjectiveManager.Instance.Check("TOILETEVENT"))
            {
                DontDoThisTwice = true;
                ObjectiveManager.Instance.Satisfy("LEVELFINISHED");
            }
            if (losesNode1 != null){_inventoryHelper.RemoveItem((BaseItem)losesNode1); }                
            if (itemToAddNode1 != null){_inventoryHelper.AddItem((BaseItem)itemToAddNode1,1);}

                if (responseNodeOne != null)
                {
                    
                    active = responseNodeOne;
                    dialogueDisplay.GetComponent<DialogueDisplay>().dialogue = active;
                    dialogueDisplay.GetComponent<DialogueDisplay>().my_update();
                    Refresh();
                }
                
                else if (LevelEvents && notChecked)
                {
                    notChecked = false;
                    levelEvents.changeDialogue();
                }
               
                else 
                {
                    Deactivate();
                }
        }
        else
        {
            Node1InvalidEnabler.SetActive(true);
            node1InvalidText.text = "you are missing required " + hasItemNode1.name + "!";
           // Debug.Log("you don't have" +  my_hasItemNode1.name);
            StartCoroutine(CloseInvalidN1());
        }
       
    }
    
    public void NextNodeR2()
    {
        if (hasItemNode2 == null || eventTracker.GetComponent<MyEventTracker>().my_CheckInventory(hasItemNode2.name)) 
        {
               if (losesNode2 != null){_inventoryHelper.RemoveItem((BaseItem)losesNode2); }
               if (itemToAddNode2 != null){_inventoryHelper.AddItem((BaseItem)itemToAddNode2,1); }

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
            node2InvalidText.text = "you are missing required " + hasItemNode2.name + "!";
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
       
        //myPlayer.GetComponent<CharacterPause>().UnPauseCharacter();
        dialogueEnabler.SetActive(false);
        if (NPCL3)
        {
            NPCl3interact.GetComponent<DontTalkWhileMoving>().ConversationOver();
        }
        StatusManager.Manager.Unpause();
        //GameManager.Instance.UnPause();
    }

/*    public void my_AddItem(InventoryItem my_itemToAdd)
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
        }

    }*/
    
}
