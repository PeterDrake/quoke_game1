using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDialogueTest : MonoBehaviour
{

    public DialogueNode tester;
    public NPC testNPC;
    private int k = 0;

    private void Start()
    {
        ObjectiveManager.Instance.Satisfy("TOILETEVENT");
    }

    private void Update()
    {
        if (k > 0)
        {
            DialogueManager.Instance.StartDialogue(tester, testNPC, Callback);
            Destroy(this);
        }
        k++;
    }

    public void Callback(DialogueNode n)
    {
        return;
    }
}
