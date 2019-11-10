using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class levelEvents : MonoBehaviour

{
    public bool toiletComplete;
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
