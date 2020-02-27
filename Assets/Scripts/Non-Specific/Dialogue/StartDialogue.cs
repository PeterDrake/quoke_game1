﻿using UnityEngine;
/// <summary>
/// Starts a dialogue with a provided npc and dialogue
/// intended to be used in conjunction InteractWithObject
/// </summary>
public class StartDialogue : MonoBehaviour
{
    [SerializeField] private NPC npc;

    [SerializeField] private DialogueNode dialogue;
    
    public void Interact()
    {
        DialogueManager.Instance.StartDialogue(dialogue,npc,SetNewHead);
    }

    // this will be called if the dialogue manager encounters a DialogueNode with the SetAsNewHead flag set to true
    private void SetNewHead(DialogueNode newHead)
    {
        dialogue = newHead;
    }
}
