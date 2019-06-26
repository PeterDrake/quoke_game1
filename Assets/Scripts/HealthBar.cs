using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider waterSlide;
    public Slider healthSlide;
    private float value;
    // Start is called before the first frame update
    void Start()
    {
        value = healthSlide.GetComponent<Slider>().value;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            value -= 1f;
            healthSlide.value = value;
        }

        if (waterSlide.value <= waterSlide.minValue)
        {
            value -= 1f;
            healthSlide.value = value;
        }

        if (healthSlide.value <= healthSlide.minValue)
        {
            Debug.Log("Game over");
        }
        
    }
}
