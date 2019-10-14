using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clobberer : MonoBehaviour
{
    public bool enabled;
    
    // Start is called before the first frame update
    void Start()
    {
        enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (enabled && other.gameObject.CompareTag("Player"))
        {
            Death.Manager.PlayerDeath("You were hit by a door!");
        }
    }
}
