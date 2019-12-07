using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.InventoryEngine;

public class loseItem : MonoBehaviour

{
    /// <summary>
    ///Player loses an item on key check. Ex. throws away gun in dumpster. 
    /// Designed for actions in game where and item would be used/removed, etc. 
    /// </summary>
    
    private bool isColliding;

    public GameObject eventTracker;

    public GameObject DialogueManager;

    public InventoryItem itemToLose;
    
    
    //checks if player is colliding, pressing 'e' and then they 'pick up' the item
    private void OnTriggerStay(Collider other) 
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown("e"))
            {
                //makes sure the player doesn't quickly double hit 'e' and get redundant effect
                if (isColliding) return;
                isColliding = true;

                if (eventTracker.GetComponent<MyEventTracker>().my_CheckInventory(itemToLose.name))
                {
                    //Debug.Log("success");
                    //DialogueManager.GetComponent<DialogueManager>().my_LoseItem(itemToLose);

                }
                else
                {
                    Debug.Log("you dont have a " + itemToLose);
                }

               

            }
            

        }
    }

    //checks if the player left (resets the IsColliding)
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isColliding = false;
        }
    }
}
