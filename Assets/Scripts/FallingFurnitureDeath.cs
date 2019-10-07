using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FallingFurnitureDeath : MonoBehaviour
{
    /// <summary>
    /// When a piece of furniture falls on the player from the quake it kills them.
    /// after it hits the ground ~1.5f it will disable the ability to kill
    /// </summary>
    
    public Slider health;
    public GameObject DeathScreen;

    public Text death;

    private bool isEnabled = true;


    private void OnEnable()
    {
        StartCoroutine(DontKill());
    }

    public IEnumerator DontKill()
    {
        yield return new WaitForSeconds(1.5f);
        isEnabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (isEnabled && other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player Hit");
            death.text = "Crushed by falling object";
            health.GetComponent<Slider>().value = health.GetComponent<Slider>().minValue;
        }
    }



}
