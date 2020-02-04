using System.Runtime.Remoting.Messaging;
using MoreMountains.InventoryEngine;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item Requirement", menuName = "Dialogue/Requirements/Items")]
public class RequireItems : DialogueRequirement
{
    public InventoryItem[] RequiredItems;
    
    [Header("Amount of each item that is required")]
    public int[] Amounts;
    
    // Need a static reference to Inventory available before this can be implemented
    public override bool TestSatisfaction()
    {
        throw new System.NotImplementedException();
    }

    public override string GetFailureMessage()
    {
        throw new System.NotImplementedException();
    }
}
