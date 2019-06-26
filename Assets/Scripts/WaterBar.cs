﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterBar : MonoBehaviour
{
    public Slider waterSlide;
    public GameObject water;
    
    public float waterValue=100;
    public float frame=-100;
    // Start is called before the first frame update
    void Start()
    {
        frame = -1000;
        waterValue = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (frame < 10)
        {
            frame++;
        }

        else
        {
            waterValue -= .05f;
            waterSlide.value = waterSlide.GetComponent<WaterBar>().waterValue;
        }
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            frame = -100;
            waterValue = 100;
            waterSlide.GetComponent<WaterBar>().waterValue = waterValue;
            StartCoroutine("Wait");
        }
    }

    IEnumerator Water()
    {
        yield return new WaitUntil(() => frame >= 10);
    }
}
