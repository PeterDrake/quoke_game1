
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.InventoryEngine;

public class TapHeater : MonoBehaviour
{
    /// <summary>
    /// "taps water heater" Essentially just a lose hose, gain water, with appropriate checks
    /// </summary>
    
    private bool isColliding;

    public GameObject eventTracker;
    
    //this is just to hijack a function from it
    public GameObject DialogueManager;
    public BaseItem water;
    public BaseItem hose;
    
    private void OnTriggerStay(Collider other) 
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown("e"))
            {
                if (isColliding) return;
                isColliding = true;

                if (eventTracker.GetComponent<MyEventTracker>().my_CheckInventory("hose"))
                {
                    Debug.Log("success");
                    DialogueManager.GetComponent<DialogueManager>().my_AddItem(water);
                    DialogueManager.GetComponent<DialogueManager>().my_LoseItem(hose);

                }
                else
                {
                    Debug.Log("you dont have a hose");
                }

               

            }
            

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isColliding = false;
        }
    }
}
