using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparentTable : MonoBehaviour
{
    public GameObject table;
        
    public Material opaqueMaterial;

    public Material transparentMaterial;

    public bool transparent;
    
    void OnTriggerEnter(Collider other)
    {
        if (!transparent && other.CompareTag("Player"))
        {
            Logger.Instance.Log("Player got under table.");
            table.GetComponent<Renderer>().material = transparentMaterial;
            transparent = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (transparent && other.CompareTag("Player"))
        {
            Logger.Instance.Log("Player got out from under table.");
            table.GetComponent<Renderer>().material = opaqueMaterial;
            transparent = false;
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        transparent = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
