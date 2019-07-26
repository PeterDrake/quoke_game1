using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class NETinfo : MonoBehaviour
{
    public GameObject sanitation;
    public GameObject objective;
    public int netTalk;

    private string shelterText;

    // Start is called before the first frame update
    void Start()
    {
        netTalk = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (netTalk>2)
        {
            sanitation.GetComponent<SanitationCheck>().netTalked = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown("e"))
            {
                netTalk++;
                shelterText = "Accomplished";
                objective.GetComponent<UpdateQuests>().updateShelter(shelterText);
            }
        }
    }
}
