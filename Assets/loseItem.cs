using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.InventoryEngine;

public class loseItem : MonoBehaviour

{
    private bool isColliding;

    public GameObject eventTracker;

    public GameObject DialogueManager;

    public InventoryItem itemToLose;
    // Start is called before the first frame update


    
    
    
    private void OnTriggerStay(Collider other) 
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown("e"))
            {
                if (isColliding) return;
                isColliding = true;

                if (eventTracker.GetComponent<MyEventTracker>().my_CheckInventory(itemToLose.name))
                {
                    //Debug.Log("success");
                    DialogueManager.GetComponent<DialogueManager>().my_LoseItem(itemToLose);

                }
                else
                {
                    Debug.Log("you dont have a " + itemToLose);
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
