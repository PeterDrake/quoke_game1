using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractText : MonoBehaviour

{
    /// <summary>
    /// Chnages the interact text
    /// </summary>

    public void ChangeText(string newInteract)
    {
        GetComponent<Text>().text = newInteract;
    }
}
