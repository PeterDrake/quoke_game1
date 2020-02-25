using System.Collections;
using UnityEngine;

/// <summary>
/// When a piece of furniture falls on the player from the quake it kills them.
/// after it hits the ground ~1.5f it will disable the ability to kill
/// </summary>
public class FallingObject : Pauseable
{
    private bool isEnabled = true;
    private Rigidbody rb;
    
    private Vector3 _velocity;
    private Vector3 _angular;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        StartCoroutine(DontKill());
    }

    private IEnumerator DontKill()
    {
        yield return new WaitForSeconds(1.5f);
        isEnabled = false;
        rb.isKinematic = true;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (isEnabled && other.gameObject.CompareTag("Player"))
        {
            DeathManager.Instance.PlayerDeath("Crushed by falling object "+ (QuakeManager.Instance.quakes == 0? "in earthquake":"in aftershock"));
        }
    }

    public override void Pause()
    {
        _velocity = rb.velocity;
        _angular = rb.angularVelocity;
        rb.isKinematic = true;
    }

    public override void UnPause()
    {
        rb.isKinematic = false;
        
        rb.velocity = _velocity ;
        rb.angularVelocity = _angular;
    }
}
