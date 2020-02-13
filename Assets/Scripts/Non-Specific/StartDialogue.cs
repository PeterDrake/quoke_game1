using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDialogue : MonoBehaviour
{
    public NPC npc;

    public DialogueNode dialogue;

    public void Interact()
    { 
        DialogueManagerTest.Instance.StartDialogue(dialogue,npc);
    }
}
