using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    public GameObject winScreen;
    public GameObject objective;
    public GameObject Level;
    public GameObject aftershockTrigger;
    public bool sanitation;
    public bool shelter;
    public bool water;
    public bool aftershock;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        sanitation = objective.GetComponent<UpdateQuests>().sanitationBool;
        shelter = objective.GetComponent<UpdateQuests>().shelterBool;
        water = objective.GetComponent<UpdateQuests>().waterBool;
        aftershock = aftershockTrigger.GetComponent<AftershockTrigger>().happened;

        if (sanitation && shelter && water && aftershock)
        {
            winScreen.SetActive(true);

        }
    }
}
