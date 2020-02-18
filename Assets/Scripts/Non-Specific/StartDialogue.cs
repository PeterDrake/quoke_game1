using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDialogue : MonoBehaviour
{
    public NPC npc;

    public DialogueNode dialogue;

    public void Interact()
    { 
        DialogueManager.Instance.StartDialogue(dialogue,npc,SetNewHead);
    }

    private void SetNewHead(DialogueNode newHead)
    {
        Debug.Log("called");
        dialogue = newHead;
    }
}
