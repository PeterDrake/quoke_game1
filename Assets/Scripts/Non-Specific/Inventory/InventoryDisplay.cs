using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryDisplay : MonoBehaviour
{
    [SerializeField] private GameObject SlotPrefab;
    // itemPanel(gameObject to display item sprites), viewPanel (to show selected item's display image/description), exit button
    // use button?

    private GameObject toggler;
    private void initialize() //Get all references that are needed to populate the dialogue UI
    {
        byte componentsFound = 0;
        Transform main = transform.Find("DialogueToggler");
        toggler = main.gameObject;
        
        foreach (Transform child in main)
        {
            switch (child.name)
            {
                case "":
                    break;
                default:
                    break;
            }
        }
        /*if (componentsFound != requiredComponentsAmount) 
            throw new Exception("Required Components for Dialogue Displayer were not found!");*/
    }
}
