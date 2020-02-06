using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Objective Outcome", menuName = "Dialogue/Outcomes/SatisfyObjective")]
public class SatisfyObjective : DialogueOutcome
{
    public string ObjectiveName;
    
    
    public override void DoOutcome(ref DialogueNode d, ref NPC n)
    {
        ObjectiveManager.Instance.Satisfy(ObjectiveName);
        Trigger = false;
    }
}
