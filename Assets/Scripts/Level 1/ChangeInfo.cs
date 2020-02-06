using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeInfo : MonoBehaviour
{
    public GameObject InfoEnabler;
    public GameObject EventTracker;
    public string textToDisplay;
    
    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            if (Input.GetKeyDown("e"))
            {
                InfoEnabler.SetActive(true);
                EventTracker.GetComponent<InformationCanvas>().DisplayInfo(textToDisplay);
                
            }
        }
        
    }


}
