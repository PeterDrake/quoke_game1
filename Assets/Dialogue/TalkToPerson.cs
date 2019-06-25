using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityScript.Steps;

public class TalkToPerson : MonoBehaviour
{
    
    public GameObject canvasEnabler;
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
                canvasEnabler.SetActive(true);
            }
        }
    }
}
