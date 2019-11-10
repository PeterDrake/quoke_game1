using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractText : MonoBehaviour
{
    /// <summary>
    /// Changes the interact text
    /// </summary>

    
    public Text text;
    private GameObject displayToggler;

    private void Start()
    {
        displayToggler = transform.GetChild(0).gameObject;
    }
    
    public void ChangeText(string newInteract)
    {
        text.text = newInteract;
        ToggleVisibility(newInteract.Length > 0);
    }

    public void ToggleVisibility(bool visible)
    {
        displayToggler.SetActive(visible);
    }
}
