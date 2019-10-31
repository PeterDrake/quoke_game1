using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class interactWithObject_old : MonoBehaviour
{
    /*
     * This Script *should be* no longer in use!
     *
     */
    
    
    
    public GameObject interactNotifier;
    public Text interactText;
    public string newInteractText;
   
    
    //This script pops up an inputted interact text to display when the player has an opportunity to do something. Ex. 'press 'E' to tap water heater'

    public void Start()
    {
        Debug.Log("Destryong IWO on "+name);
        Destroy(this);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactNotifier.SetActive(true);
            interactText.GetComponent<InteractText>().ChangeText(newInteractText);
        }
        
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactNotifier.SetActive(false);
        }
    }
}
