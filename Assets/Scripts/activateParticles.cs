using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateParticles : MonoBehaviour
{
    public GameObject particles;
    float timer;
    bool highlighted;

    // Update is called once per frame
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            particles.SetActive(true);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            particles.SetActive(false);
 
        }
    }
}