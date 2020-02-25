
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class PlayerPauser : Pauseable
{
    private ThirdPersonUserControl _control;
    private Rigidbody rb;
    private Vector3 vel;
    private Vector3 ang;
    private new void Start()
    {
        base.Start();
        _control = GetComponent<ThirdPersonUserControl>();
        rb = GetComponent<Rigidbody>();
    }

    public override void Pause()
    {
        ang = rb.angularVelocity;
        vel = rb.velocity;
        rb.isKinematic = true;
        _control.enabled = false;
    }

    public override void UnPause()
    {
        _control.enabled = true;
        rb.isKinematic = false;
        rb.angularVelocity = ang;
        rb.velocity = vel;
    }
}
