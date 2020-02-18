using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.TopDownEngine;
using UnityEngine;
using UnityEngine.UI;
using UnityScript.Steps;

public class TalkToPerson : MonoBehaviour
{
    /// <summary>
    /// handles how to start/which conversation you will have with an NPC. Pauses game during a conversation. 
    /// </summary>

    public old_Dialogue mainOldDialogue;
    public old_Dialogue newHead;
    public GameObject dialogueCanvas;
    public GameObject canvasEnabler;
    public GameObject interactNotifier;
    public levelEvents LevelEvents;
    
    
    private bool head_flag;
    private bool isColliding;

    IEnumerator my_pause()
    {
        yield return new WaitForSeconds(1f);
    }

    IEnumerator Reset()
    {
        yield return new WaitForEndOfFrame();
        isColliding = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactNotifier.GetComponent<InteractText>().ChangeText("Press 'E' to talk");
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactNotifier.GetComponent<InteractText>().ToggleVisibility(false);
        }
    }

    private void OnTriggerStay(Collider other) 
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetAxis("Interact") > 0)
            {
                if(isColliding) return;
                isColliding = true;
                if (ObjectiveManager.Instance.Check("TOILETEVENT"))
                {
                    LevelEvents.changeDialogue();
                }
                canvasEnabler.SetActive(true);
                interactNotifier.GetComponent<InteractText>().ToggleVisibility(false);
                
                
                //If the player has already talked to the NPC the NPCs new head will be displayed
                if (head_flag == false)
                {
                    dialogueCanvas.GetComponent<old_DialogueDisplay>().oldDialogue = mainOldDialogue;
                    //head_flag = true;
                    StartCoroutine(my_pause());
                }
                else
                {
                    dialogueCanvas.GetComponent<old_DialogueDisplay>().oldDialogue = newHead;
                }
                
                dialogueCanvas.GetComponent<old_DialogueDisplay>().my_update(); 
                dialogueCanvas.GetComponent<old_DialogueManager>().Refresh();
                StartCoroutine(Reset());
            }
        }
    }
}
