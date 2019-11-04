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

    /*
     * If all 3 quests have been completed and the aftershock happened
     *     let the player win
     * 
     */
    void Update()
    {
        sanitation = objective.GetComponent<UpdateQuests>().sanitationBool;
        shelter = objective.GetComponent<UpdateQuests>().shelterBool;
        water = objective.GetComponent<UpdateQuests>().waterBool;
        aftershock = aftershockTrigger.GetComponent<AftershockTrigger_old>().happened;

        if (sanitation && shelter && water && aftershock)
        {
            winScreen.SetActive(true);

        }
    }
}
