using System.Collections;
using System.Collections.Generic;
using MoreMountains.TopDownEngine;
using UnityEngine;

public class Blinking_Children : MonoBehaviour
{
    public Material blinking;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        blinking = GetComponent<BlinkingObject>().my_blink;
        if (string.Compare(blinking.name,"TeleporterBlue")==0)
        {
//           
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).GetComponent<BlinkingObject>().my_blink = blinking;
            }

        }
    
    }
    
    
}
