using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Boo.Lang;
using Boo.Lang.Environments;
using UnityEngine;
using Cinemachine;
using UnityEngine.Rendering.PostProcessing;
using MoreMountains.Feedbacks;
using MoreMountains.FeedbacksForThirdParty;
using MoreMountains.Tools;

public class AftershockTrigger : MonoBehaviour
{
    
        public float amplitude;
        public float frequency;
        public float duration;
        
        public GameObject my_camera;
        public GameObject my_bookshelf;
        public GameObject straps;
        public GameObject aftershock;
        public GameObject InfoEnabler;
        public GameObject EventTracker;
        public GameObject tableCheck;
        public GameObject rearranger;
        
        public String textToDisplay1;
        public string textToDisplay2;
        public string textToDisplay3;

        public bool tableFlag = true;
        public bool cheatQuake = false;
        public bool happened = false;
        
        
        // Start is called before the first frame update
        void Start()
        {
            tableFlag = true;
            StartCoroutine(QuakeDown());

        }
        
        /*
         * cheat the aftershock and start it early
         * Tell the player to go rearrange the bookcase
         * 
         */
        
        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown("p"))
            {
               quakeTrigger();
               cheatQuake = true;
            }
            
            if (!rearranger.GetComponent<Rearrange>().safe) 
            {
                InfoEnabler.SetActive(true);
                EventTracker.GetComponent<InformationCanvas>().DisplayInfo(textToDisplay1);
            }
        }
        
        /*
         * wait for 15sec if the earthquake is not started early, then start it
         */

        public IEnumerator QuakeDown()
        {
           yield return new WaitForSeconds(15f);
           if (cheatQuake == false)
           {
               quakeTrigger();   
           }
        }
        
        /*
         * while the player is not under the table, shake the earth,
         * tell the player to go under the table and hold on;
         * after the earthquake disable aftershock and information canvas
         * 
         */

        public IEnumerator ShakeIt()
        {
            while (tableFlag)
            {
                InfoEnabler.SetActive(true);
                EventTracker.GetComponent<InformationCanvas>().DisplayInfo(textToDisplay2);
                my_camera.GetComponent<MMCinemachineCameraShaker>().ShakeCamera(duration, amplitude, frequency, false);
                yield return new WaitForSeconds(duration);
            }
            
            InfoEnabler.SetActive(false);
            happened = true;
            EventTracker.GetComponent<InformationCanvas>().DisplayInfo(textToDisplay3);
            InfoEnabler.SetActive(false);
            aftershock.SetActive(false);
        }
        
        
        /*
         * start the shake it coroutine
         * make the bookshelf fall;
         * 
         */

        private void quakeTrigger()
        {
            StartCoroutine(ShakeIt());
            tableCheck.SetActive(true);
            my_bookshelf.GetComponent<MyFallingObject>().Fall();
           
        }
}
