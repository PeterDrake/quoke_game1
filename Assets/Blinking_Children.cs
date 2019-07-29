using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using MoreMountains.TopDownEngine;
using UnityEngine;

public class Blinking_Children : MonoBehaviour
{
    public Material mat;
    public Material blinking;
    // Start is called before the first frame update
    void Start()
    {

    }

    /**
     * Make all the children of this gameObject blink when this one starts to
     * by comparing the name of the blinking material on the parent and the material 'mat' given in the script
     */
    void Update()
    {
        blinking = GetComponent<BlinkingObject>().my_blink;
        if (string.Compare(blinking.name,mat.name)==0)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).GetComponent<BlinkingObject>().my_blink = blinking;
            }
        }
    }
    
}
