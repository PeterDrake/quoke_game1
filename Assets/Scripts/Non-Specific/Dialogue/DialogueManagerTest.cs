using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManagerTest : MonoBehaviour
{
    public DialogueDisplayer displayer;
    public static DialogueManagerTest Instance;

    private bool active;
    private DialogueNode activeDialogue;
    private NPC activeNPC;

    /// <summary> Starts the given dialogue with the given NPC </summary>
    public void StartDialogue(DialogueNode d, NPC n)
    {
        Debug.Log("Starting");
        activeDialogue = d;
        activeNPC = n;
        displayer.Load(d,n);
    }
    
    /// <summary> End the current dialogue if one is active</summary>
    /// <returns> A new head if one was reached</returns>
    public DialogueNode EndDialogue()
    {
        displayer.End();
        return activeDialogue;
    }
    
    
    private void Awake()
    {
        // Singleton pattern
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }

    private void Start()
    {
        if (displayer == null) throw new Exception("Dialogue Manager has no displayer!");
        displayer.LinkEvents(OptionOneSelected, OptionTwoSelected, Exit);
    }
    
    private string OptionOneSelected()
    {
        activeDialogue = activeDialogue.optionOne;
        displayer.Load(activeDialogue, activeNPC);
        return "";
    }
    
    private string OptionTwoSelected()
    {
        activeDialogue = activeDialogue.optionTwo;
        displayer.Load(activeDialogue, activeNPC);
        
        return "";
    }

    private string Exit()
    {
        EndDialogue();
        return "";
    }
    
    
    
}
