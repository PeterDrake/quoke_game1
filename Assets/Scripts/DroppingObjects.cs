using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DroppingObjects : MonoBehaviour
{
    // Start is called before the first frame update
    public float thrust;
    public Rigidbody rb;
    public Slider health;
    
    
    //public Vector3 push_point;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Drop()
    {
       // rb.AddRelativeForce(Vector3.up * thrust);
        //Debug.Log("fallen");
    }
    
    
    //how do we ensure that the Earthquake is actually happening?
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player Hit");
            health.GetComponent<Slider>().value -= 5f;

        }
        else
        {
//            rb.useGravity = false;
//            GetComponent<Rigidbody>().useGravity = false;
        }

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            GetComponent<Rigidbody>().useGravity = false;
            
        }

        else if (other.gameObject.CompareTag("Player"))
        {
            health.GetComponent<Slider>().value -= 5f;
        }
      
    }
}
