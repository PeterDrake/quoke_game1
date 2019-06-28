using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyFallingObject : MonoBehaviour
{
    public float thrust;
    public Rigidbody rb;

    public GameObject DeathScreen;
    //public Vector3 push_point;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Fall()
    {
        rb.AddRelativeForce(Vector3.forward * thrust);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player Hit");
            DeathScreen.GetComponent<Death>().PlayerDeath();
            
        }

    }
}
