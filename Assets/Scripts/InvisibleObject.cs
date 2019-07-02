using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleObject : MonoBehaviour
{
    
    public GameObject roof;
        
    public Material opaqueMaterial;

    public Material transparentMaterial;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    /* If the player is under any of these roofs, make the ceiling transparent
     * Make it opaque otherwise
     */
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered the trigger");
            roof.GetComponent<Renderer>().material = transparentMaterial;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player exited the trigger");
            roof.GetComponent<Renderer>().material = opaqueMaterial;
        }
    }
}
