using System.Collections;
using System.Collections.Generic;
using MoreMountains.Tools;
using UnityEngine;
using UnityEngine.UI;

public class UpdateQuests : MonoBehaviour
{

    public Text waterText;
    public Text shelterText;
    public Text sanitationText;

    public GameObject shelter;
    public GameObject water;
    public GameObject sanitation;

    public void updateWater(string newWaterText)
    {
        waterText.GetComponent<Text>().text = newWaterText;
        water.GetComponent<Image>().color = Color.green;
    }
    
    public void updateShelter(string newShelterText)
    {
        shelterText.GetComponent<Text>().text = newShelterText;
        shelter.GetComponent<Image>().color = Color.green;
    }
    
    public void updateSanitation(string newSanitationText)
    {
        sanitationText.GetComponent<Text>().text = newSanitationText;
        sanitation.GetComponent<Image>().color = Color.green;
    }
    
    
}
