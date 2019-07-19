using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Boo.Lang;
using UnityEngine;
using Cinemachine;
using UnityEngine.Rendering.PostProcessing;
using MoreMountains.Feedbacks;
using UnityEngine.SceneManagement;

namespace MoreMountains.FeedbacksForThirdParty
{

    public class MyShakeTrigger : MonoBehaviour
    {

        public GameObject my_camera;
        public float amplitude;
        public float frequency;
        public float duration;
       // public GameObject gas;
        public GameObject my_bookshelf;
       // public GameObject light1;
        //public Material mat;
        
       // private Rigidbody lightRB;

        public GameObject InfoEnabler;
        public GameObject EventTracker;
        public String textToDisplay1;

        public string textToDisplay2;

        public GameObject fallingLights;
        public GameObject enableDoors;

        public bool tableFlag = true;
        public bool cheatQuake = false;

        private string sceneName;

        // Start is called before the first frame update
        void Start()
        {
            //lightRB= light1.GetComponent<Rigidbody>();
            tableFlag = true;
            StartCoroutine(QuakeDown());
            Scene currentScene = SceneManager.GetActiveScene ();
            sceneName = currentScene.name;
//            Debug.Log(sceneName);
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
                my_camera.GetComponent<MMCinemachineCameraShaker>().ShakeCamera(duration, amplitude, frequency);
                yield return new WaitForSeconds(duration);


            }
            EventTracker.GetComponent<InformationCanvas>().DisplayInfo(textToDisplay2);
            enableDoors.SetActive(false);
            
        }
        
        
        

        private void quakeTrigger()
        {
            InfoEnabler.SetActive(true);
            EventTracker.GetComponent<InformationCanvas>().DisplayInfo(textToDisplay1);
            StartCoroutine(ShakeIt());
           // my_camera.GetComponent<MMCinemachineCameraShaker>().ShakeCamera(duration, amplitude, frequency);
           if (string.Compare(sceneName, "Level 1") ==0)
           {
               my_bookshelf.GetComponent<MyFallingObject>().Fall();
           }
           fallingLights.GetComponent<QuakeFurniture>().Drop();

        }
    }
}
