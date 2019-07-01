using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparentTable : MonoBehaviour
{
    public GameObject table;
        
   public Material opaqueMaterial;

    public Material transparentMaterial;
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered the trigger");
            table.GetComponent<Renderer>().material = transparentMaterial;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player exited the trigger");
            table.GetComponent<Renderer>().material = opaqueMaterial;
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
