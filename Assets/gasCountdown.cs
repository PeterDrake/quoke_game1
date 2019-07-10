using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gasCountdown : MonoBehaviour
{

    public Text death;

    public Slider health;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(gasExplosion());
        }
    }

    public IEnumerator gasExplosion()
    {
        yield return new WaitForSeconds(15f);
        death.text = "YOU DIED OF A GAS EXPLOSION :(";
        health.GetComponent<Slider>().value = health.GetComponent<Slider>().minValue;
    }
}
