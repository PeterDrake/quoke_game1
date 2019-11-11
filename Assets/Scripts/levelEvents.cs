using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class levelEvents : MonoBehaviour

{
    private bool toiletComplete;
    private Dialogue active;
    public Dialogue conditionMet; //if condition is met
    public Dialogue conditionNotMet; //if condition is not met

    public DialogueManager myManager;

    public GameObject NPC;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeDialogue()
    {

        ///Peter H modify this call at some point to return the number to check for 2 buckets
        if (GetComponent<MyEventTracker>().my_CheckInventory("Bucket")
            && GetComponent<MyEventTracker>().my_CheckInventory("Sawdust")
            && GetComponent<MyEventTracker>().my_CheckInventory("Bag")
            && GetComponent<MyEventTracker>().my_CheckInventory("Sanitizer"))
        {
            toiletComplete = true;
        }
        
        
        if (toiletComplete)
        {
            active = conditionMet;
        }
        else
        {
            active = conditionNotMet;
          ///  Debug.Log("trying to switch");
        }

        NPC.transform.GetComponent<TalkToPerson>().mainDialogue = active;
        myManager.dialogueDisplay.GetComponent<DialogueDisplay>().dialogue = active;
        myManager.dialogueDisplay.GetComponent<DialogueDisplay>().my_update();
        myManager.Refresh();
    }
}
