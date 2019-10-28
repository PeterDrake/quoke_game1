using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using MoreMountains.FeedbacksForThirdParty;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


public class UnderTable : MonoBehaviour
{
    public GameObject fallingObjects;
    public GameObject aftershocktrigger;
    public GameObject quakeTrigger;
    public GameObject tableCheck;


    public UnityEvent OnUnderTable;
    // Start is called before the first frame update

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            OnUnderTable.Invoke(); 
    } 
}
