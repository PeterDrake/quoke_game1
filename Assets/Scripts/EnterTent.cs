using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterTent : MonoBehaviour
{
    public GameObject eventTracker;
    private bool isColliding;

    //checks if player has gun and if they can/cant enter the tent
    private void OnTriggerStay(Collider other) 
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown("e"))
            {
                if (isColliding) return;
                isColliding = true;

                if (eventTracker.GetComponent<MyEventTracker>().my_CheckInventory("Handgun"))
                {
                    Debug.Log("you cant come in with a gun");

            
                }
                else
                {
                    Debug.Log("you can enter, you win");
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
