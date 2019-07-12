using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class BucketsExist : MonoBehaviour
{
    public GameObject starter;
    public GameObject buckets;
    public GameObject eventTracker;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (starter.active == false)
        {
            if ((eventTracker.GetComponent<MyEventTracker>().my_CheckInventory("Bucket")))
            {
                Debug.Log(" buckets in there");
                buckets.SetActive(false);
            }
            
        }
        
    }

    void BucketInventory()
    {
       

    }
    


}
