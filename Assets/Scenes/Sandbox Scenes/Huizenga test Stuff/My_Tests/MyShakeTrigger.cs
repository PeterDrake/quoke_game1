using System;
using System.Collections;
using System.Collections.Generic;
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
        public GameObject my_bookshelf;
        public GameObject light1;
        private Rigidbody lightRB;
        
        // Start is called before the first frame update
        void Start()
        {
            //lightRB= light1.GetComponent<Rigidbody>();

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                {
                    my_camera.GetComponent<MMCinemachineCameraShaker>().ShakeCamera(duration,amplitude, frequency);
                    
                    //testing bookshelf
                    my_bookshelf.GetComponent<MyFallingObject>().Fall();
                    
                 //   Debug.Log(lightRB.GetComponent<Rigidbody>().useGravity);
                    light1.GetComponent<Rigidbody>().useGravity = true;
                 
                    //light1.GetComponent<Rigidbody>().AddRelativeForce(Vector3.down*2);
                    Debug.Log("light fallen");


                }
            }
            
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                light1.GetComponent<Rigidbody>().useGravity = false;

            }
        }
    }
}
