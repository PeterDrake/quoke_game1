﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InformationCanvas : MonoBehaviour
{
    
    // changes the what the information canvas displays 'Exit the house', 'Turn off the gas' , etc.

    public GameObject textCanvas;
    

    public void DisplayInfo(string textToDisplay)
    {
        textCanvas.GetComponent<Text>().text = textToDisplay;
    }
    
}
