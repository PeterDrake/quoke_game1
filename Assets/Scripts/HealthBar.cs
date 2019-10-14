using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider waterSlide;

    private float value;
    
    
    /*
     * if the player's water drains to 0,
     * their health depletes to 0,
     *
     * if the health is 0, they die
     */

    private void Start()
    {
        Debug.Log("This script is no longer used, deleting! 'HealthBar'");
        Destroy(this);
    }

    void Update()
    {
        if (waterSlide.value <= waterSlide.minValue)
        {
            value -= 2f;
        }

        /*if (healthSlide.value <= healthSlide.minValue)
        {
            death.GetComponent<Death>().PlayerDeath("You Died");
        }*/
        
    }
}
