using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeInfo : MonoBehaviour
{
    public GameObject InfoEnabler;
    public GameObject EventTracker;
    public string textToDisplay;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            if (Input.GetKeyDown("e"))
            {
             //   Debug.Log("info Enabled");
                InfoEnabler.SetActive(true);
                EventTracker.GetComponent<InformationCanvas>().DisplayInfo(textToDisplay);
                
            }
        }
        
    }


}
