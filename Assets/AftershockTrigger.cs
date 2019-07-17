using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Boo.Lang;
using UnityEngine;
using Cinemachine;
using UnityEngine.Rendering.PostProcessing;
using MoreMountains.Feedbacks;
using MoreMountains.FeedbacksForThirdParty;
using MoreMountains.Tools;

public class AftershockTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    
        public GameObject my_camera;
        public float amplitude;
        public float frequency;
        public float duration;
        public GameObject my_bookshelf;
        public GameObject straps;
        public GameObject aftershock;
        public GameObject InfoEnabler;
        public GameObject EventTracker;
        public String textToDisplay1;
        public string textToDisplay2;
        public string textToDisplay3;
        public bool tableFlag = true;
        public bool cheatQuake = false;
        
        // public GameObject fallingLights;
        //public GameObject enableDoors;
        // public GameObject light1;
        //public Material mat;
        // public GameObject gas;
        // private Rigidbody lightRb;
        
        
        // Start is called before the first frame update
        void Start()
        {
            //lightRB= light1.GetComponent<Rigidbody>();
            tableFlag = true;
            StartCoroutine(QuakeDown());

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown("p"))
            {
               quakeTrigger();
               cheatQuake = true;
            }
        }
        
        

        public IEnumerator QuakeDown()
        {
           yield return new WaitForSeconds(15f);
           if (cheatQuake == false)
           {
               quakeTrigger();   
           }
           //yield return new WaitForSeconds(10f);
           //InfoEnabler.SetActive(false);
           //EventTracker.GetComponent<InformationCanvas>().DisplayInfo(textToDisplay2);
          // enableDoors.SetActive(false);
        }

        public IEnumerator ShakeIt()
        {
            while (tableFlag)
            {
                EventTracker.GetComponent<InformationCanvas>().DisplayInfo(textToDisplay2);
                my_camera.GetComponent<MMCinemachineCameraShaker>().ShakeCamera(duration, amplitude, frequency);
                yield return new WaitForSeconds(duration);
            }
            
            EventTracker.GetComponent<InformationCanvas>().DisplayInfo(textToDisplay3);
            aftershock.SetActive(false);
//            enableDoors.SetActive(false);
        }
        
        
        

        private void quakeTrigger()
        {
            InfoEnabler.SetActive(true);
            if (straps.active == false) 
            {
                EventTracker.GetComponent<InformationCanvas>().DisplayInfo(textToDisplay1);
            }
            StartCoroutine(ShakeIt());
            
            my_bookshelf.GetComponent<MyFallingObject>().Fall();
            //fallingLights.GetComponent<QuakeFurniture>().Drop();
            // my_camera.GetComponent<MMCinemachineCameraShaker>().ShakeCamera(duration, amplitude, frequency);

            
        }
}
