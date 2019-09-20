using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameMaster : MonoBehaviour
{

    public bool Bucket;

    public bool PlasticBag;

    public bool Poop;

    public bool ToiletPaper;

    public bool Sawdust;

    public bool Pee;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckCorrect()
    {
        if (Bucket && PlasticBag && Poop && ToiletPaper && Sawdust && Pee)
        {
            Debug.Log("You solved the puzzle");
        }
        else
        {
            Debug.Log("Something isn't in the right place");
        }
    }
    
}
