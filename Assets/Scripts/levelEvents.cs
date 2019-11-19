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
    
    public void changeDialogue()
    {

        if (ObjectiveManager.Instance.Check("TOILETEVENT"))
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
          
        }

        NPC.transform.GetComponent<TalkToPerson>().mainDialogue = active;
        myManager.dialogueDisplay.GetComponent<DialogueDisplay>().dialogue = active;
        myManager.dialogueDisplay.GetComponent<DialogueDisplay>().my_update();
        myManager.Refresh();
    }
}
