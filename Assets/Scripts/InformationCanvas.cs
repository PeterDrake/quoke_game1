using System.Collections;
using System.Collections.Generic;
using MoreMountains.TopDownEngine;
using UnityEngine;
using UnityEngine.UI;

public class InformationCanvas : MonoBehaviour
{
    public Text info;
    public GameObject textCanvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayInfo(string textToDisplay)
    {
        textCanvas.GetComponent<Text>().text = textToDisplay;
    }

  
}
