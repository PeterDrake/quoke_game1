using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FallingFurnitureDeath : MonoBehaviour
{
    
    public Slider health;
    public GameObject DeathScreen;

    public Text death;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player Hit");
            death.text = "Crushed by falling object";
            health.GetComponent<Slider>().value = health.GetComponent<Slider>().minValue;

        }
    }

}
