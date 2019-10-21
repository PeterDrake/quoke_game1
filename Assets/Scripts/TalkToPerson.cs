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

    public Dialogue mainDialogue;
    public Dialogue newHead;
    public GameObject dialogueCanvas;
    public GameObject canvasEnabler;
    public GameObject interactNotifier;

    public Text InteractText;
    
    private bool head_flag;
    private GameObject myPlayer;
   // public GameObject myGameManager;
    
   //this NPCl3 will probably go...but leave it for now please - Peter H
   public bool NPCL3 ;

    private bool isColliding;
    
    // Start is called before the first frame update
    //finds player
    void Start()
    {
        head_flag = false;
        isColliding = false;
        myPlayer = GameObject.FindWithTag("FakePlayer");

    }


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
            interactNotifier.SetActive(true);
            InteractText.GetComponent<InteractText>().ChangeText("Press 'E' to talk");
            
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactNotifier.SetActive(false);
           
        }
    }

    private void OnTriggerStay(Collider other) 
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown("e"))
            {
                if(isColliding) return;
                isColliding = true;
                canvasEnabler.SetActive(true);
                
                //Pauses the character while they are in dialogue .. come back to this..
                /*
                myPlayer.GetComponent<CharacterPause>().PauseCharacter();
                GameManager.Instance.Pause();
                */

                
                //If the player has already talked to the NPC the NPCs new head will be displayed
                if (head_flag == false)
                {
                    dialogueCanvas.GetComponent<DialogueDisplay>().dialogue = mainDialogue;
                    //head_flag = true;
                    StartCoroutine(my_pause());
                }
                
                else
                {
                    dialogueCanvas.GetComponent<DialogueDisplay>().dialogue = newHead;
                }
                
                dialogueCanvas.GetComponent<DialogueDisplay>().my_update(); 
                dialogueCanvas.GetComponent<DialogueManager>().Refresh();
                StartCoroutine(Reset());
                
            }
        }
    }
}
