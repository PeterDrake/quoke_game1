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
        foreach (DialogueRequirement requirement in IfRequirementsOne)
        {
            if (!requirement.TestSatisfaction()) return optionOneAlt;
        }
        return optionOne;
    }
    public override DialogueNode GetNodeTwo()
    {
        foreach (DialogueRequirement requirement in IfRequirementsTwo)
        {
            if (!requirement.TestSatisfaction()) return optionTwoAlt;
        }
        return optionTwo;
    }

    public override string GetTextOne()
    {
        foreach (DialogueRequirement requirement in IfRequirementsTwo)
        {
            if (!requirement.TestSatisfaction()) return optionOneTextAlt;
        }
        return optionOneText;
    }
    public override string GetTextTwo()
    {
        foreach (DialogueRequirement requirement in IfRequirementsTwo)
        {
            if (!requirement.TestSatisfaction()) return optionTwoTextAlt;
        }
        return optionTwoText;
    }
}
