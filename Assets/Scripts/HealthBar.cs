using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider waterSlide;
    public Slider healthSlide;
    private float value;
    
    public GameObject death;

    public Text deathText;
    // Start is called before the first frame update
    void Start()
    {
        value = healthSlide.GetComponent<Slider>().value;

    }

    // Update is called once per frame
    void Update()
    {

       //Dying of Dehydration
        if (waterSlide.value <= waterSlide.minValue)
        {
            value -= 1f;
            healthSlide.value = value;
            deathText.GetComponent<Text>().text = "You died of dehydration";
        }

        if (healthSlide.value <= healthSlide.minValue)
        {
            death.GetComponent<Death>().PlayerDeath();
        }
        
    }
}
