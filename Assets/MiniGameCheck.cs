using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameCheck : MonoBehaviour
{

    public string correctTag;

    private MiniGameMaster MasterCheck;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(correctTag))
        {
            //Debug.Log(correctTag +" is correct");
            MasterCheck = GameObject.Find("MinigameMaster").GetComponent<MiniGameMaster>();
            if (correctTag == "Blue")
            {
                MasterCheck.Blue = true;
            }
            if (correctTag == "Orange")
            {
                MasterCheck.Orange = true;
            }
            if (correctTag == "Green")
            {
                MasterCheck.Green = true;
            }
        }
        else
        {
            //Debug.Log("An item is in the wrong place"); 
        }
    }
    
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(correctTag))
        {
            //Debug.Log(correctTag +" is correct");
            MasterCheck = GameObject.Find("MinigameMaster").GetComponent<MiniGameMaster>();
            if (correctTag == "Blue")
            {
                MasterCheck.Blue = false;
            }
            if (correctTag == "Orange")
            {
                MasterCheck.Orange = false;
            }
            if (correctTag == "Green")
            {
                MasterCheck.Green = false;
            }
        }
        else
        {
            //Debug.Log("An item is in the wrong place"); 
        }
    } 
    
}
