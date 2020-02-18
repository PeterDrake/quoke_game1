using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MoreMountains.InventoryEngine;

public class old_DialogueDisplay : MonoBehaviour
{
    /// <summary>
    ///This script translates the info from the dialogue scriptable object and actually displays it on the screen
    /// </summary>
    
    public old_Dialogue oldDialogue;

    public Image artworkImage; 
    public Text nameText;
    public Text NPCText;

    public Text ResponseOne;
    public old_Dialogue nextNodeOne;
    
    public Text ResponseTwo;
    public old_Dialogue nextNodeTwo;

    public InventoryItem itemToReceive;
    public InventoryItem hasItem;
    
    //put in info for different node
    public InventoryItem itemToReceiveNode1;
    public InventoryItem itemToReceiveNode2; 
    public InventoryItem hasItemNode1;
    public InventoryItem hasItemNode2;
    public InventoryItem PlayerLosesNode1;
    public InventoryItem PlayerLosesNode2;
    

    private void Start()
    {
        my_update();
    }


    public void my_update()
    {
        artworkImage.sprite = oldDialogue.NPCimage;
        nameText.text = oldDialogue.NPCname;
        NPCText.text = oldDialogue.NPCtext;

        ResponseOne.text = oldDialogue.ResponseOne;
        nextNodeOne = oldDialogue.nextNodeOne;

        ResponseTwo.text = oldDialogue.ResponseTwo;
        nextNodeTwo = oldDialogue.nextNodeTwo;

        itemToReceiveNode1 = oldDialogue.PlayerReceivesNode1;
        hasItemNode1 = oldDialogue.DoesPlayerHaveNode1;
        itemToReceiveNode2 = oldDialogue.PlayerReceivesNode2;
        hasItemNode2 = oldDialogue.DoesPlayerHaveNode2;

        PlayerLosesNode1 = oldDialogue.PlayerLosesNode1;
        PlayerLosesNode2 = oldDialogue.PlayerLosesNode2;



    }
}
