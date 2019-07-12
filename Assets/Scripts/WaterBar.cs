﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Water;

public class WaterBar : MonoBehaviour
{
    public Slider waterSlide;
    public GameObject water;
    
    public float waterValue=100;

    public int frame;
    
    // Start is called before the first frame update
//    void Start()
//    {
//        frame = -1000;
//=======
//    public float frame=-100;

    // Start is called before the first frame update
    void Start()
    {
        frame = -50;
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
//            if (waterValue <50)
//            {
//                waterValue -= .005f;
//            }
//            else
//            {
//                waterValue -= .0005f;
//
//            }
            waterValue -= .01f; //figure out the water draining speed
            waterSlide.value = waterSlide.GetComponent<WaterBar>().waterValue;
        }
        
    }

//    void OnTriggerEnter(Collider other)
//    {
//        if (other.CompareTag("Player"))
//        {
//            
//            waterSlide.GetComponent<WaterBar>().frame = -1000;
//            waterValue = 100;
//            waterSlide.GetComponent<WaterBar>().waterValue = waterValue;
//            water.SetActive(false);
//        }
//        
//    }


}
