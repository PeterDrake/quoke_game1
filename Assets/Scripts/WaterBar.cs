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
    public Slider waterSlider;
    public GameObject starterInventory;
    
    public float waterValue = 100;
    public float rate = .01f;
    
    private int safety_frames = 60;
    
    void Start()
    {
        Debug.Log("WaterBar Created");
        waterValue = 100;

    }

    /**
     * After the player has picked from the starter inventory
     * Drain the water at a small rate,
     * if the water level reaches 0, the person dies. 
     */
    
    void Update()
    {
        if (starterInventory.activeSelf == false)
        {
            if (safety_frames > 0)
            {
                safety_frames--;
            }
            else
            {
                waterValue -= rate;
                waterSlider.value = waterValue; // set slider to reflect hydration
                
                if (waterValue <= 0)
                {
                    Death.Manager.PlayerDeath("Dehydration ended you!");
                    Destroy(this);
                }
            }

            
        }
        
    }

}
