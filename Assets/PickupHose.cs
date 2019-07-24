using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.InventoryEngine;

public class PickupHose : MonoBehaviour
{
    
    
    private bool isColliding;

    public BaseItem hose;
    public GameObject ThisGameObject;

    //this is just to hijack a function from it
    public GameObject DialogueManager;
   
    private void OnTriggerStay(Collider other) 
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown("e"))
            {
                if (isColliding) return;
                isColliding = true;

                DialogueManager.GetComponent<DialogueManager>().my_AddItem(hose);

                ThisGameObject.SetActive(false);

            }
            

        }
    }
}
