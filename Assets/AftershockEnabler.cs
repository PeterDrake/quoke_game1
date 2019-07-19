using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

/**
 * Enable the start of counting down on the aftershock*
 */
public class AftershockEnabler : MonoBehaviour
{
    public GameObject aftershock;

// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
/**
 * If the player enters the house, enable the aftershock gameobject and start the domino coroutine
 */
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("NPC2"))
        {
           // Debug.Log("Aftershock starter");
            aftershock.SetActive(true);
        }
    }
}
