using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.FeedbacksForThirdParty;
using UnityEngine;

public class UnderTable : MonoBehaviour
{

    public GameObject fallingObjects;

    public GameObject quakeTrigger;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            quakeTrigger.GetComponent<MyShakeTrigger>().tableFlag = false;
            fallingObjects.GetComponent<QuakeFurniture>().underTable = false;
        }
    } 
}
