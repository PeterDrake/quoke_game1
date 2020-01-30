using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableAfterQuake : MonoBehaviour
{
    /// <summary>
    /// Door locks disable after quakes
    /// </summary>
    
    public GameObject thisDoor;


    public void enableDoors()
    {
        thisDoor.SetActive(false);
    }
}

