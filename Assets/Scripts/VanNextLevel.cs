using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VanNextLevel : MonoBehaviour
{
    private const string EventKey = "LEVELFINISHED";
    private const string SATISFIED = "Press 'e' to rest in Ahmad's van";
    private const string NOT_SATISFIED = "";
    
    private InteractWithObject _interact;
    private bool _satisfied = false;
    
    private void Start()
    {
        _interact = GetComponent<InteractWithObject>();
        ObjectiveManager.Instance.Register(EventKey,() => _satisfied = true);
    }
    
    public void OnEnter()
    {
        _interact.SetInteractText(_satisfied? SATISFIED:NOT_SATISFIED);
        _interact.BlinkWhenPlayerNear = _satisfied;
    }
    public void Interaction()
    {
        if (_satisfied) SceneManager.LoadScene("DemoMenu", LoadSceneMode.Single);
    }
}
