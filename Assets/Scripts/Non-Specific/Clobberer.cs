using System;
using UnityEngine;

/// <summary>
///  When the player enters a collider with this script they will be killed
/// </summary>
public class Clobberer : Pauseable
{
    public bool enabled;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (enabled && other.gameObject.CompareTag("Player"))
        {
            DeathManager.Instance.PlayerDeath("You were hit by a door!");
        }
    }

    public override void Pause()
    {
        rb.isKinematic = true;
    }

    public override void UnPause()
    {
        rb.isKinematic = false;
    }
}
