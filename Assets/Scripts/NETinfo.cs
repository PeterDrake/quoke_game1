//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Security.Cryptography.X509Certificates;
//using UnityEngine;
//
//public class NETinfo : MonoBehaviour
//{
//    public GameObject sanitation;
//    public GameObject objective;
//
//    private string shelterText;
//
//    // Start is called before the first frame update
//    void Start()
//    {
//    }
//
//    // Update is called once per frame
//    void Update()
//    {
//       
//    }
//    
//    
//
//    private void OnTriggerStay(Collider other)
//    {
//        if (other.CompareTag("Player"))
//        {
//            if (Input.GetKeyDown("e"))
//            {
//                shelterText = "Accomplished";
//                objective.GetComponent<UpdateQuests>().updateShelter(shelterText);
//            }
//        }
//    }
//}
