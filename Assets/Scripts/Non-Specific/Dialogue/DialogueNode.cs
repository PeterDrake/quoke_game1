using UnityEngine;

[CreateAssetMenu(fileName = "New DialogueNode", menuName = "Dialogue/Node")]
public class DialogueNode : ScriptableObject
{
    public string speech;
    
    [SerializeField] protected string optionOneText;
    [SerializeField] protected string optionTwoText;

    [SerializeField] protected DialogueNode optionOne;
    [SerializeField] protected DialogueNode optionTwo;

    public virtual DialogueNode GetNodeOne()
    { return optionOne; }
    public virtual DialogueNode GetNodeTwo()
    { return optionTwo; }

    public virtual string GetTextOne()
    {
        return optionOneText;
    }
    public virtual string GetTextTwo()
    {
        return optionTwoText;
    }
}
