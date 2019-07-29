using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gasCountdown : MonoBehaviour
{
    /// <summary>
    /// countdown for gas explosion. Starts after talking to NPC. players has x seconds to turn off the gas before they die
    /// </summary>
    
    public Text death;
    public Slider health;

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(gasExplosion());
        }
    }

    public IEnumerator gasExplosion()
    {
        
        // this number controls time until explosion
        yield return new WaitForSeconds(15f);
        death.text = "YOU DIED OF A GAS EXPLOSION :(";
        health.GetComponent<Slider>().value = health.GetComponent<Slider>().minValue;
    }
}
