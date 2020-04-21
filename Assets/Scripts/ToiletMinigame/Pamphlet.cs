using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Pamphlet : MonoBehaviour
{
    public GameObject pamphlet;
    public Text buttonText;

    private string openText = "Open Pamphlet";
    private string closeText = "Close Pamphlet";

    private bool open;

    private void Awake()
    {
        pamphlet.SetActive(false);
        buttonText.text = openText;
    }

    public void toggle()
    {
        if (open)
        {
            pamphlet.SetActive(false);
            buttonText.text = openText;
        }
        else
        {
            pamphlet.SetActive(true);
            buttonText.text = closeText;
        }
        open = !open;
    }

}

