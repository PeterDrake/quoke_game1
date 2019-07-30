using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HousingQuest : MonoBehaviour
{
    private string shelterText;

    public GameObject objective;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    /**
     *After talking to the NET officer make the housing quest accomplished
     */
    
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown("e"))
            {
                shelterText = "Accomplished";
                objective.GetComponent<UpdateQuests>().updateShelter(shelterText);
            }
        }
    }
}
