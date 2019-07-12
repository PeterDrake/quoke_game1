using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Boo.Lang;
using UnityEngine;
using Cinemachine;
using UnityEngine.Rendering.PostProcessing;
using MoreMountains.Feedbacks;

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
        


        // Start is called before the first frame update
        void Start()
        {
            //lightRB= light1.GetComponent<Rigidbody>();
            StartCoroutine(QuakeDown());

        }

        // Update is called once per frame
        void Update()
        {

        }

        public IEnumerator QuakeDown()
        {
           yield return new WaitForSeconds(15f);
           quakeTrigger();
           yield return new WaitForSeconds(10f);
           //InfoEnabler.SetActive(false);
           EventTracker.GetComponent<InformationCanvas>().DisplayInfo(textToDisplay2);


        }
        
        
        

        private void quakeTrigger()
        {
            InfoEnabler.SetActive(true);
            EventTracker.GetComponent<InformationCanvas>().DisplayInfo(textToDisplay1);
            my_camera.GetComponent<MMCinemachineCameraShaker>().ShakeCamera(duration,amplitude, frequency);
                    
            my_bookshelf.GetComponent<MyFallingObject>().Fall();
            fallingLights.GetComponent<QuakeFurniture>().Drop();



            //   Debug.Log(lightRB.GetComponent<Rigidbody>().useGravity);
            //light1.GetComponent<Rigidbody>().useGravity = true;

            //  gas.GetComponent<BlinkingObject>().my_blink = mat;

            //light1.GetComponent<Rigidbody>().AddRelativeForce(Vector3.down*2);
//                    Debug.Log("light fallen");




        }

        
    }
}
