using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingObject : MonoBehaviour

{


    //public GameObject thisObject;
    public Material my_default;

    public Material my_blink;
    private MeshRenderer my_meshrenderer;

    private int flag;
    // Start is called before the first frame update
    void Start()
    {
        //my_default = GetComponent<MeshRenderer>().materials[0];
        my_meshrenderer = GetComponent<MeshRenderer>();
        flag = 0;
        StartCoroutine(Blink());
    }

    
    IEnumerator Blink()
    {
        while (true)
        {
            //Debug.Log("blink");
            if (flag == 0)
            {
                yield return new WaitForSeconds(1f);
                my_meshrenderer.material = my_blink;
               // Debug.Log(GetComponent<MeshRenderer>().materials[0]);

                flag = 1;
                
            }
            else
            {
                yield return new WaitForSeconds(.5f);
                my_meshrenderer.material = my_default;
                flag = 0;  
                
            }
        }
    }
    
}
