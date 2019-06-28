using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.InventoryEngine;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "Create Dialogue")]
public class Dialogue : ScriptableObject
{
    public string NPCname;
    public Sprite NPCimage;
    public string NPCtext;

    public string ResponseOne;
    public Dialogue nextNodeOne; 
    
    public string ResponseTwo;
    public Dialogue nextNodeTwo;

    //public InventoryItem PlayerReceives;
    //public InventoryItem DoesPlayerHave;
    
    public InventoryItem PlayerReceivesNode1;
    public InventoryItem PlayerReceivesNode2; 
    public InventoryItem DoesPlayerHaveNode1;
    public InventoryItem DoesPlayerHaveNode2;
}
