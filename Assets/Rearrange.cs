using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class Rearrange : MonoBehaviour
{
    public bool rearrange = false;

    public GameObject protector;
    public GameObject npc2;
    public GameObject straps;
    public GameObject interactNotifier;
    public Text interactText;
    public GameObject bookcase;
    public bool safe;
    
    private bool strapsOff;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        strapsOff = straps.activeSelf;
        
        strapsOff = straps.activeSelf;
        if (rearrange)
        {
            if(Input.GetKeyDown("r"))
            {
                protector.SetActive(true);
                bookcase.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
                bookcase.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
                
                if (npc2.GetComponent<FollowPlayer>().waterGiven)
                {
                    npc2.GetComponent<FollowPlayer>().follow = true;
                    npc2.GetComponent<FollowPlayer>().goBookshelf = false;
                }
            
                safe = true;
                interactNotifier.SetActive(false);
                
            }
        }

        if (strapsOff)
        {
            safe = true;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.CompareTag("Player")) && (!strapsOff))
        {
            rearrange = true;
            interactNotifier.SetActive(true);
            interactText.text = "Press R to rearrange furniture";
        }

//
//        if ((other.CompareTag("Player")) && (strapsOff == false))
//        {
//            
//
//
//        }
    }
}
