using UnityEngine;

public class SinkInteraction : MonoBehaviour
{
    private bool _firstInteraction = true;

    private InteractWithObject _interact;
    private void Start()
    {
        _interact = GetComponent<InteractWithObject>();
    }

    public void Interaction()
    {
        if (!_firstInteraction) Systems.Status.AffectHydration(50);
        else
        {
            _firstInteraction = false;
            _interact.SetInteractText("Press 'E' to Drink from Sink");
            _interact.DeleteItems();
            _interact = null;
        }
    }
}