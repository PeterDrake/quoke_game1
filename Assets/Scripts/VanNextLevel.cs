using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VanNextLevel : MonoBehaviour
{
    private const string SATISFIED = "Press 'e' to take a rest in Adam's van.";
    private const string NOT_SATISFIED = "";
    
    private InteractWithObject _interact;
    private bool satisfied = false;
    private void Start()
    {
        ObjectiveManager.Instance.Register("BOOKCASE",() => satisfied = true);
        _interact = GetComponent<InteractWithObject>();
    }
    
    public void OnEnter()
    {
        _interact.SetInteractText(satisfied? SATISFIED:NOT_SATISFIED);
    }
    public void Interaction()
    {
        if (satisfied) SceneManager.LoadScene("DemoMenu", LoadSceneMode.Single);
    }
}
