using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Objective Requirement", menuName = "Dialogue/Requirements/Objective")]
public class RequireEvent : DialogueRequirement
{
    public string requiredEvent;
    
    [Header("Can be empty")]
    public new string failureMessage;
    
    public override bool TestSatisfaction()
    {
        return ObjectiveManager.Instance.Check(requiredEvent);
    }

    public override string GetFailureMessage() { return failureMessage; }
}
