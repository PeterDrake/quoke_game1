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

    
    public GameObject rearranger;
    public Rearrange _rearranger;
    
    public GameObject npc2;
    public bool isEnabled = false;
    
    public bool isSceneTwo;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //_rearranger = rearranger.GetComponent<Rearrange>();
    }

    public void Fall()
    {
        rb.isKinematic = false;
        isEnabled = true;
        rb.AddRelativeForce(Vector3.forward * thrust);
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
