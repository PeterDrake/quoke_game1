using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using MoreMountains.InventoryEngine;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Water;

public class WaterBar : MonoBehaviour
{
    public Slider waterSlide;
    public GameObject starterInventory;
    public float waterValue=100;
    public float rate = .01f;

    public int frame;
    
    public Text deathText;



    // Start is called before the first frame update
    void Start()
    {
        frame = -50;
        waterValue = 100;

    }

    // Update is called once per frame
    
    /**
     * After the player has picked from the starter inventory
     * Drain the water at a small rate,
     * if the water level reaches 0, the person dies. 
     */
    void Update()
    {
        if (starterInventory.activeSelf == false)
        {
            if (frame < 10)
            {
                frame++;
            }
            else
            {
                waterValue -= rate;
                waterSlide.value = waterSlide.GetComponent<WaterBar>().waterValue;
            }

            if (waterSlide.GetComponent<Slider>().value <= waterSlide.GetComponent<Slider>().minValue)
            {
                deathText.text = "Dehydration ended you!";
            }
        }
        
    }

}
