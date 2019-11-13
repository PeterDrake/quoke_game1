using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using MoreMountains.FeedbacksForThirdParty;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


public class PlayerInArea : MonoBehaviour
{
    private bool playerInCollider;
    public UnityEvent OnEnter;

    public UnityEvent OnExit;
    // Start is called before the first frame update

    private BoxCollider _triggerCollider; 
    
    private void Start()
    {
        _triggerCollider = Array.Find(GetComponents<BoxCollider>(), (element) => element.isTrigger == true);
    }




    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            OnEnter.Invoke();
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnExit.Invoke();
        }

    }
}
