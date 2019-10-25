using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MyFallingObject : MonoBehaviour
{
    public float thrust;
    public Rigidbody rb;

    
    /*public GameObject rearranger;
    public Rearrange _rearranger;
    
    public GameObject npc2;*/
    public bool isEnabled = false;

    void Start()
    {
        Debug.Log("this script is no longer used! use bookcase instead");
        Destroy(this);
        rb = GetComponent<Rigidbody>();
    }

    public void Fall()
    {
        Debug.Log("called");
        rb.isKinematic = false;
        isEnabled = true;
        rb.AddRelativeForce(Vector3.forward * thrust);
    }

    public void Disable()
    {
        Destroy(rb);
        Destroy(GetComponent<BoxCollider>());
        Destroy(this);
    }

    
    public void OnTriggerEnter(Collider other)
    {
        if (isEnabled && other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player Hit");
            Death.Manager.PlayerDeath("Your bookcase crushed you to death! :(");
        }
    }
    
    
}
