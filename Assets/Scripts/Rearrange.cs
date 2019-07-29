using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

/*
 * For the empty game object that checks for collision with the bookcase
 */
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

    /*
     * if hte player is close enough to the bookcase and presses 'r'
     *     set the protector bookcase to true, disable rigidbody movements
     * if the player is also with the waterNPC,
     *     make the NPC follow the player again,
     *     and disable the go to bookshelf method.
     */
    
    // Update is called once per frame
    void Update()
    {
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
    
    /*
     * If the player enters the trigger area and the bookcase was not strapped,
     * tell the player to press r to rearrange the furniture
     */

    private void OnTriggerEnter(Collider other)
    {
        if ((other.CompareTag("Player")) && (!strapsOff))
        {
            rearrange = true;
            interactNotifier.SetActive(true);
            interactText.GetComponent<InteractText>().ChangeText("Press R to rearrange furniture");

        }
        
    }
    
    /*
     * if the player leaves the trigger area, turn the interact notifier off.
     */

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactNotifier.SetActive(false);
        }
    }
}
