using UnityEngine;

public class BedInteraction : MonoBehaviour
{
    private bool _firstInteraction = true;

    private InteractWithObject _interact;
    private void Start()
    {
        _interact = GetComponent<InteractWithObject>();
    }

    public void Interaction()
    {
        Systems.Status.AffectWarmth(50);
        _firstInteraction = false;
        _interact.SetInteractText("Press 'E' to Rest in Bed");
        _interact.DeleteItems();
        _interact = null;
    }
}