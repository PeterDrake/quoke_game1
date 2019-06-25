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
        
        // Start is called before the first frame update
        void Start()
        {

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
                    

                }
            }
        }

       
    }
}
