using UnityEngine;

/// <summary>
///  When the player enters a collider with this script they will be killed
/// </summary>
public class Clobberer : MonoBehaviour
{
    public bool enabled;

    private void OnCollisionEnter(Collision other)
    {
        if (enabled && other.gameObject.CompareTag("Player"))
        {
            Systems.Status.PlayerDeath("You were hit by a door!");
        }
    }
}
