using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{
    public Material material1;
    public Material material2;
    public GameObject yourObject;
    float timer;
    bool highlighted;

    // Update is called once per frame
    void OnTriggerStay(Collider other) 
    {
        timer += Time.deltaTime;
        if (other.CompareTag("Player"))
        {
            if (timer > 1)
            {
                timer = 0;
                if (highlighted)
                {
                    yourObject.GetComponent<MeshRenderer>().material = material1;
                    highlighted = false;
                }
                else
                {
                    yourObject.GetComponent<MeshRenderer>().material = material2;
                    highlighted = true;
                }
            }
        }
    }
    
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            yourObject.GetComponent<MeshRenderer>().material = material1;
 
        }
    }
}

                