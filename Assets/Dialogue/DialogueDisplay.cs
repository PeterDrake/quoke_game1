using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MoreMountains.InventoryEngine;

public class DialogueDisplay : MonoBehaviour
{
    public Dialogue dialogue;

    public Image artworkImage; 
    public Text nameText;
    public Text NPCText;

    public Text ResponseOne;
    public Dialogue nextNodeOne;
    
    public Text ResponseTwo;
    public Dialogue nextNodeTwo;

    public InventoryItem itemToReceive;
    public InventoryItem hasItem;

    private void Start()
    {
        my_update();
    }


    public void my_update()
    {
        artworkImage.sprite = dialogue.NPCimage;
        nameText.text = dialogue.NPCname;
        NPCText.text = dialogue.NPCtext;

        ResponseOne.text = dialogue.ResponseOne;
        nextNodeOne = dialogue.nextNodeOne;

        ResponseTwo.text = dialogue.ResponseTwo;
        nextNodeTwo = dialogue.nextNodeTwo;

        itemToReceive = dialogue.PlayerReceives;
        hasItem = dialogue.DoesPlayerHave;


    }
}
