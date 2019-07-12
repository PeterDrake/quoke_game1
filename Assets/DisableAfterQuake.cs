using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableAfterQuake : MonoBehaviour
{
    public GameObject thisDoor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void enableDoors()
    {
        thisDoor.SetActive(false);
    }
}

