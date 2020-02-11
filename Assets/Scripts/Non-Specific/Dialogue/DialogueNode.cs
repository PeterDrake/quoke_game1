using UnityEngine;

[CreateAssetMenu(fileName = "New DialogueNode", menuName = "Dialogue/Node")]
public class DialogueNode : ScriptableObject
{
    public string speech;
    
    [SerializeField] protected string optionOneText;
    [SerializeField] protected string optionTwoText;

    [SerializeField] protected DialogueNode optionOne;
    [SerializeField] protected DialogueNode optionTwo;
    
    [SerializeField] private DialogueRequirement[] Requirements;
    [SerializeField] private DialogueOutcome[] Outcomes;

    public virtual DialogueNode GetNodeOne() { return optionOne; }
    public virtual DialogueNode GetNodeTwo() { return optionTwo; }
    public virtual string GetTextOne() { return optionOneText; }
    public virtual string GetTextTwo() { return optionTwoText; }
    
    public string CheckRequirements()
    {
        if (Requirements != null)
            return CheckRequirements(Requirements);
        
        return "";
    }

    protected string CheckRequirements(DialogueRequirement[] dr)
    {
        foreach (DialogueRequirement req in dr)
        {
            if (req == null) continue;
            if (!req.TestSatisfaction()) return req.GetFailureMessage();
        }

        return "";
    }


    public void DoOutcomes(ref NPC n)
    {
        foreach (DialogueOutcome oc in Outcomes)
        {
            oc.DoOutcome(ref n);
        }
    }
}
