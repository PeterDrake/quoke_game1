using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameCheck : MonoBehaviour
{

    public string correctTag;

    private MiniGameMaster MasterCheck;
   

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(correctTag))
        {
            //Debug.Log(correctTag +" is correct");
            MasterCheck = GameObject.Find("MinigameMaster").GetComponent<MiniGameMaster>();
            if (correctTag == "Bucket")
            {
                MasterCheck.Bucket = true;
            }
            if (correctTag == "PlasticBag")
            {
                MasterCheck.PlasticBag = true;
            }
            if (correctTag == "Poop")
            {
                MasterCheck.Poop = true;
            }
            if (correctTag == "ToiletPaper")
            {
                MasterCheck.ToiletPaper = true;
            }
            if (correctTag == "Sawdust")
            {
                MasterCheck.Sawdust = true;
            }
            if (correctTag == "Pee")
            {
                MasterCheck.Pee = true;
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
            MasterCheck = GameObject.Find("MinigameMaster").GetComponent<MiniGameMaster>();
            if (correctTag == "Bucket")
            {
                MasterCheck.Bucket = false;
            }
            if (correctTag == "PlasticBag")
            {
                MasterCheck.PlasticBag = false;
            }
            if (correctTag == "Poop")
            {
                MasterCheck.Poop = false;
            }
            if (correctTag == "ToiletPaper")
            {
                MasterCheck.ToiletPaper = false;
            }
            if (correctTag == "Sawdust")
            {
                MasterCheck.Sawdust = false;
            }
            if (correctTag == "Pee")
            {
                MasterCheck.Pee = false;
            }
        }
        else
        {
            //Debug.Log("An item is in the wrong place"); 
        }
    } 
    
}
