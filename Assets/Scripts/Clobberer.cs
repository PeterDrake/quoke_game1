using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clobberer : MonoBehaviour
{
    private Death death; // How we announce death

    public bool enabled;
    
    // Start is called before the first frame update
    void Start()
    {
        death = GameObject.FindGameObjectWithTag("Death").GetComponent<Death>();
        enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            death.PlayerDeath("You were hit by a door!");
        }
    }
}
