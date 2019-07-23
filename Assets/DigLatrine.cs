using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigLatrine : MonoBehaviour
{
    
    private bool isColliding;

    public GameObject eventTracker;
   
    private void OnTriggerStay(Collider other) 
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown("e"))
            {
                if (isColliding) return;
                isColliding = true;

                if (eventTracker.GetComponent<MyEventTracker>().my_CheckInventory("shovel"))
                {
                    Debug.Log("success");
                }
                else
                {
                    Debug.Log("you dont have a shovel");
                }

               

            }
            

        }
    }
}
