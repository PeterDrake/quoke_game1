using System.Collections;
using System.Collections.Generic;
using MoreMountains.Tools;
using UnityEngine;
using UnityEngine.UI;

public class SanitationCaller : MonoBehaviour
{
    public GameObject sanitationCanvas;
    public Slider health;
    public GameObject eventTracker;
    public Text death;
    public GameObject objective;
    public Text sanitation;

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
