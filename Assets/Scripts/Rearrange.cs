using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rearrange : MonoBehaviour
{
    public bool rearrange = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("rearrange object");
            rearrange = true;
        }
    }
}
