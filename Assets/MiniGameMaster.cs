using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameMaster : MonoBehaviour
{
    public bool Orange;

    public bool Green;

    public bool Blue; 
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
        if (Orange && Green && Blue)
        {
            Debug.Log("You solved the puzzle");
        }
        else
        {
            Debug.Log("Something isn't in the right place");
        }
    }
    
}
