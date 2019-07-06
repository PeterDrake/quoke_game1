using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyFallingObject : MonoBehaviour
{
    public float thrust;
    public Rigidbody rb;
    public Slider health;
    public GameObject DeathScreen;

    public Text death;
    //public Vector3 push_point;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Fall()
    {
        rb.AddRelativeForce(Vector3.forward * thrust);
    }
    
    

    //how do we ensure that the Earthquake is actually happening?
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player Hit");
            death.text = "Your bookcase crashed you to death! :(";
            health.GetComponent<Slider>().value = health.GetComponent<Slider>().minValue;
//          DeathScreen.GetComponent<Death>().PlayerDeath();

        }

    }
}
