using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class ChangeMaterial : MonoBehaviour
{
    private Material material1;
    private Material material2;
    private float timer;
    private bool highlighted;
    private bool inCollider;
    
    public void Start()
    { 
       material1 = gameObject.GetComponent<MeshRenderer>().material;
       material2 = Resources.Load("Transparent Object 1", typeof(Material)) as Material;
    }
    
    void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Player"))
        {
            inCollider = true;
        }
    }
    
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inCollider = false;
            gameObject.GetComponent<MeshRenderer>().material = material1;
 
        }
    }

    public void FixedUpdate()
    {
        if (inCollider)
        {
            timer += Time.deltaTime;
            if (timer > .6)
            {
                timer = 0;
                if (highlighted)
                {
                    gameObject.GetComponent<MeshRenderer>().material = material1;
                    highlighted = false;
                }
                else
                {
                    gameObject.GetComponent<MeshRenderer>().material = material2;
                    highlighted = true;
                }
            }
        }
    }
}

                