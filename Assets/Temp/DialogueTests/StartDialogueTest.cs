using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDialogueTest : MonoBehaviour
{

    public DialogueNode tester;
    public NPC testNPC;
    private int k = 0;

    private void Update()
    {
        if (k > 0)
        {
            DialogueManagerTest.Instance.StartDialogue(tester, testNPC);
            Destroy(this);
        }
        k++;
    }
}
