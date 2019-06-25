using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactWithObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown("e"))
            {
                Debug.Log("This has been activated");
            }
        }
    }
}
