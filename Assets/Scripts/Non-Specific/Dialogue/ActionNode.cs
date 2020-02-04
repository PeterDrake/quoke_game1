using UnityEngine;

[CreateAssetMenu(fileName = "New DialogueNode", menuName = "Dialogue/ActionNode")]
public class ActionNode : DialogueNode
{
    public DialogueRequirement[] Requirements;
    public DialogueOutcome[] Outcomes;
}