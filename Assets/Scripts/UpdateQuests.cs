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
    public GameObject infoEnabler;
    public bool shelterBool = false;
    public bool waterBool = false;
    public bool sanitationBool = false;

    /*
     * After a quest has been completed,
     * change the text, turn the icon and turn the bool to true
     * 
     */
    public void updateWater(string newWaterText)
    {
        waterText.GetComponent<Text>().text = newWaterText;
        water.GetComponent<Image>().color = Color.green;
        waterBool = true;
    }
    
    public void updateShelter(string newShelterText)
    {
        shelterText.GetComponent<Text>().text = newShelterText;
        shelter.GetComponent<Image>().color = Color.green;
        shelterBool = true;
    }
    
    public void updateSanitation(string newSanitationText)
    {
        sanitationText.GetComponent<Text>().text = newSanitationText;
        sanitation.GetComponent<Image>().color = Color.green;
        sanitationBool = true;
    }
    
    
}
