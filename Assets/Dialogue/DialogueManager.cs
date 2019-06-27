using System.Collections;
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

    public InventoryItem my_itemToAdd;
    public Inventory my_targetInventory;
    
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
        my_itemToAdd = dialogueDisplay.GetComponent<DialogueDisplay>().itemToReceive;

    }

    public void NextNodeR1()
    {
        // button click should change the active node to the next node... 
        if (responseNodeOne != null){ 
            active = responseNodeOne; /// this isn't actually changing the active?
            dialogueDisplay.GetComponent<DialogueDisplay>().dialogue = active;                          
            dialogueDisplay.GetComponent<DialogueDisplay>().my_update();
            Refresh();
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
    
    public void NewHead ()
    {
        dialogueDisplay.GetComponent<DialogueDisplay>().dialogue = newHead;
        dialogueDisplay.GetComponent<DialogueDisplay>().my_update();
        Refresh();
    }

    public void Deactivate()
    {
        my_AddItem(); // just here temporarily for testing 
      //  NewHead();
        dialogueEnabler.SetActive(false);
    }

    public void my_AddItem()
    {
      //  my_itemToAdd = dialogueDisplay.GetComponent<DialogueDisplay>().itemToReceive;
        my_targetInventory.AddItem(my_itemToAdd, 1);
    }
    
}
