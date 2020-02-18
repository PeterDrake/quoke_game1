using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.InventoryEngine;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "Create Dialogue")]
public class old_Dialogue : ScriptableObject
{
    /// <summary>
    /// Scriptable object script for creating dialogues
    /// </summary>
    
    public string NPCname;
    public Sprite NPCimage;
    public string NPCtext;

    public string ResponseOne;
    public old_Dialogue nextNodeOne; 
    
    public string ResponseTwo;
    public old_Dialogue nextNodeTwo;
    
    public InventoryItem PlayerReceivesNode1;
    public InventoryItem PlayerReceivesNode2; 
    public InventoryItem DoesPlayerHaveNode1;
    public InventoryItem DoesPlayerHaveNode2;
    public InventoryItem PlayerLosesNode1;
    public InventoryItem PlayerLosesNode2;
}
