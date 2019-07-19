using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateQuests : MonoBehaviour
{

    public Text waterText;
    public Text shelterText;
    public Text sanitationText;
    


    public void updateWater(string newWaterText)
    {
        waterText.GetComponent<Text>().text = newWaterText;
    }
    
    public void updateShelter(string newShelterText)
    {
        shelterText.GetComponent<Text>().text = newShelterText;
    }
    
    public void updateSanitation(string newSanitationText)
    {
        sanitationText.GetComponent<Text>().text = newSanitationText;
    }

    
    
    
}
