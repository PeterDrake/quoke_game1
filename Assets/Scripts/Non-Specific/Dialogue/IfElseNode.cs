using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New DialogueNode", menuName = "Dialogue/IfElseNode")]
public class IfElseNode : DialogueNode
{
    public DialogueRequirement[] IfRequirementsOne;
    public DialogueRequirement[] IfRequirementsTwo;
    
    [SerializeField] private string optionOneTextAlt;
    [SerializeField] private string optionTwoTextAlt;

    [SerializeField] private DialogueNode optionOneAlt;
    [SerializeField] private DialogueNode optionTwoAlt;

    public override DialogueNode GetNodeOne()
    {
        return (CheckRequirements(IfRequirementsOne) == "") ? optionOne : optionOneAlt;
    }
    public override DialogueNode GetNodeTwo()
    {
        return (CheckRequirements(IfRequirementsTwo) == "") ? optionTwo : optionTwoAlt;
    }

    public override string GetTextOne()
    {
        return (CheckRequirements(IfRequirementsOne) == "") ? optionOneText : optionOneTextAlt;
    }
    public override string GetTextTwo()
    {
        return (CheckRequirements(IfRequirementsTwo) == "") ? optionTwoText : optionTwoTextAlt;
    }
}
