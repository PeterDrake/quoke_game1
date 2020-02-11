using System.Collections;
using System.Collections.Generic;
using MoreMountains.InventoryEngine;
using UnityEngine;

[CreateAssetMenu(fileName = "New Add Items Outcome", menuName = "Dialogue/Outcomes/GiveItem")]
public class GiveItems : DialogueOutcome
{
    public InventoryItem[] RequiredItems;
    
    [Header("Amount of each item that will be added")]
    public int[] Amounts;
    
    // Need a static reference to Inventory available before this can be implemented
    public override void DoOutcome(ref NPC n)
    {
        throw new System.NotImplementedException();
    }
}
