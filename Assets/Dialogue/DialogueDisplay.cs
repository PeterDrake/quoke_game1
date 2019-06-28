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
    
    //put in info for different node
    public InventoryItem itemToReceiveNode1;
    public InventoryItem itemToReceiveNode2; 
    public InventoryItem hasItemNode1;
    public InventoryItem hasItemNode2;
    

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

        itemToReceiveNode1 = dialogue.PlayerReceivesNode1;
        hasItemNode1 = dialogue.DoesPlayerHaveNode1;
        itemToReceiveNode2 = dialogue.PlayerReceivesNode2;
        hasItemNode2 = dialogue.DoesPlayerHaveNode2;



    }
}
