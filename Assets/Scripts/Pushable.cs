using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;



/**
 * 
 *Make the bookcase pushable*
 * 
 **/

public class Pushable : MonoBehaviour
{
    public GameObject straps;
    public GameObject protector;
    private bool strapsOff;
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
        if ((other.CompareTag("Player"))&&(strapsOff == false))
        {
           // Debug.Log("can move the bookcase");
           protector.SetActive(true);
           GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
           GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ;
           GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
           transform.Translate(Time.deltaTime, 0, 0,Space.Self);
            
        }
    }
}
