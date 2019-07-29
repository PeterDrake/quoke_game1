﻿using System;
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
    public Slider health;
    public GameObject rearranger;
    public GameObject DeathScreen;
    public GameObject npc2;
    public Text death;
    public bool isEnabled = false;

    private Scene currentScene;

    private string sceneName;
    //public Vector3 push_point;
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        rb = GetComponent<Rigidbody>();

    }

    public void Fall()
    {
        if (string.Compare(sceneName, "Level 2")==0)
        {
            if (rearranger.GetComponent<Rearrange>().safe == false)
            {
                Debug.Log(rearranger.GetComponent<Rearrange>().safe);
                isEnabled = true;
                rb.AddRelativeForce(Vector3.forward * thrust);
                StartCoroutine(BookshelfDeactivate());
            }
        }
        else
        {
            isEnabled = true;
            rb.AddRelativeForce(Vector3.forward * thrust);
            StartCoroutine(BookshelfDeactivate());
        }
        
    }
    
    
    public IEnumerator BookshelfDeactivate()
    {
        yield return new WaitForSeconds(2f);
        isEnabled = false; 
        GetComponent<Rigidbody>().isKinematic = true;
        if (string.Compare(sceneName, "Level 2")==0)
        {
            npc2.GetComponent<FollowPlayer>().fall = true;
        }

    }


    //how do we ensure that the Earthquake is actually happening?
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if ((isEnabled))
            {
                Debug.Log("Player Hit");
                death.text = "Your bookcase crushed you to death! :(";
                health.GetComponent<Slider>().value = health.GetComponent<Slider>().minValue;
            }
        }
    }
    
    
}
