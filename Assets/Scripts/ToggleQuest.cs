using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleQuest : MonoBehaviour
{
    public GameObject waterQuest;
    public GameObject sanitationQuest;
    public GameObject shelterQuest;
    private bool isOpen = false;

    
    // Start is called before the first frame update
    void Start()
    {
        isOpen = false;
    }

   

    void Update() 
    {
        if (Input.GetKeyDown("o") && isOpen == false)
        {
            waterQuest.SetActive(true);
            sanitationQuest.SetActive(true);
            shelterQuest.SetActive(true);
            isOpen = true;
            Debug.Log(isOpen);


        }

        else if (Input.GetKeyDown("o") && isOpen == true)
        {
            waterQuest.SetActive(false);
            sanitationQuest.SetActive(false);
            shelterQuest.SetActive(false); 
            isOpen = false;
            Debug.Log(isOpen);

        }

        
        
        
    }
}
