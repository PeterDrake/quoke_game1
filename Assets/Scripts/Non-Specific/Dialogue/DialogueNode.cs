using UnityEngine;

[CreateAssetMenu(fileName = "New DialogueNode", menuName = "Dialogue/Node")]
public class DialogueNode : ScriptableObject
{
    public string speech;
    
    public string optionOneText;
    public string optionTwoText;

    public DialogueNode optionOne;
    public DialogueNode optionTwo;
    
    public DialogueRequirement[] Requirements;
    public DialogueOutcome[] Outcomes;

}
