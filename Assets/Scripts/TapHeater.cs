
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapHeater : MonoBehaviour
{
    private bool isColliding;

    public GameObject eventTracker;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

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
                }
                else
                {
                    Debug.Log("you dont have a hose");
                }

               

            }
            

        }
    }
}
