using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class levelEvents : MonoBehaviour

{
    private bool toiletComplete;
    private old_Dialogue active;
    public old_Dialogue conditionMet; //if condition is met
    public old_Dialogue conditionNotMet; //if condition is not met

    public old_DialogueManager myManager;

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

        NPC.transform.GetComponent<TalkToPerson>().mainOldDialogue = active;
        myManager.dialogueDisplay.GetComponent<old_DialogueDisplay>().oldDialogue = active;
        myManager.dialogueDisplay.GetComponent<old_DialogueDisplay>().my_update();
        myManager.Refresh();
    }
}
