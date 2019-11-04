using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.TopDownEngine;
using UnityEngine;
using UnityEngine.UI;

public class InformationCanvas : MonoBehaviour
{

    
    // changes the what the information canvas displays 'Exit the house', 'Turn off the gas' , etc.

    public Text info;
    public GameObject textCanvas;

    private GameObject toggle;

    private void Start()
    {
        toggle = transform.Find("InfoCanvasToggle").gameObject;
    }


    public void ToggleDisplay(bool status)
    {
        toggle.SetActive(status);    
    }
    
    public void DisplayInfo(string textToDisplay)
    {
        ToggleDisplay(true);
        info.text = textToDisplay;
    }

}
