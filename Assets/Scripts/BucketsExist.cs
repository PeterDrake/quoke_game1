using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Boo.Lang.Environments;
using UnityEngine;

public class BucketsExist : MonoBehaviour
{
    public GameObject starter;
    public GameObject bucket1;
    public GameObject eventTracker;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
     void Update()
    {
        
        
    }

    public void BucketInventory()
    {
        if (starter.active == false)
        {
            if ((eventTracker.GetComponent<MyEventTracker>().my_CheckInventory("Bucket")))
            {
                bucket1.SetActive(false);

            }
            
        }
    }

//    private void OnTriggerEnter(Collider other)
//    {
//        
//        if (eventTracker.GetComponent<MyEventTracker>().my_CheckInventory("Bucket"))
//        {
//            buckets.SetActive(false);
//        }
//    }
}
