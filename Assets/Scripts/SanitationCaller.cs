using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using MoreMountains.Tools;
using UnityEngine;
using UnityEngine.UI;

public class SanitationCaller : MonoBehaviour
{
    public GameObject sanitationCanvas;
    public GameObject eventTracker;
    public GameObject starter;
    public Slider health;
    public Text death;
    public GameObject objective;
    public Text sanitation;
    public Text buttonText;
    
    private bool bushPoop;
    private bool sanitationPoo;
// Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PoopTime());
    }

    // Update is called once per frame
    void Update()
    {
        if (bushPoop)
        {
            if (Input.GetKeyDown("b"))
            {
                health.GetComponent<Slider>().value = 0;
                death.text = "Lack of Sanitation killed you!";
            }
        }
        if (starter.activeSelf == false)
        {
            if (GetComponent<SanitationCheck>().spUsed)
            {
                buttonText.text = "Find the rest of the carbon and make the toilet";
            }

            if (eventTracker.GetComponent<MyEventTracker>().my_CheckInventory("Sanitation Pamphlet"))
            {
                buttonText.text = "Use the sanitation pamphlet";

            }
        }
    }

    IEnumerator PoopTime()
    {
       yield return new WaitForSeconds(120f);
       if (objective.GetComponent<UpdateQuests>().sanitationBool == false)
       {
           sanitationCanvas.SetActive(true);
       }
    }

    public void PoopInBushDeath()
    {
        sanitationCanvas.SetActive(false);
        bushPoop = true;
        
    }

    public void SanitationFind()
    {
        sanitationPoo = true;
        sanitationCanvas.SetActive(false);
        if (!eventTracker.GetComponent<MyEventTracker>().my_CheckInventory("Sanitation Pamphlet"))
        {
            sanitation.text = "Find the NET";
        }
    }


}
