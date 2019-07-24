using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using MoreMountains.InventoryEngine;
//using NUnit.Framework.Internal.Commands;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Water;


public class WaterBar : MonoBehaviour
{
    public Slider waterSlide;
    
    public float waterValue=100;
    public float rate = .01f;

    public int frame;

    
    public Text deathText;

    public Inventory mainInventory;
//
//    private int wIndex;

    // Start is called before the first frame update
    void Start()
    {
        frame = -50;
        waterValue = 100;

    }

    // Update is called once per frame
    
    /**
     * Drain the water
     */
    void Update()
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
