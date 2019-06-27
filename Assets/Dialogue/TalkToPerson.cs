﻿using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.TopDownEngine;
using UnityEngine;
using UnityScript.Steps;

public class TalkToPerson : MonoBehaviour
{

    public Dialogue mainDialogue;
    public Dialogue newHead;
    public GameObject dialogueCanvas;
    public GameObject canvasEnabler;
    private bool head_flag;

    private bool isColliding;
    // Start is called before the first frame update
    void Start()
    {
        head_flag = false;
        isColliding = false;
    }

    // Update is called once per frame
    void Update()
    {
        
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

    private void OnTriggerStay(Collider other) // this is triggering it too much.. So Iscolliding/Reset make sure we avoid duplicate calls
    {
        if (other.CompareTag("Player"))
        {
           
            if (Input.GetKeyDown("e"))
            {
                if(isColliding) return;
                isColliding = true;
                
                canvasEnabler.SetActive(true);
                if (head_flag == false)
                {
                    dialogueCanvas.GetComponent<DialogueDisplay>().dialogue = mainDialogue;
                    head_flag = true;
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
