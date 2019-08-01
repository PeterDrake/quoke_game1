using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using Boo.Lang;
using UnityEngine;
using Cinemachine;
using UnityEngine.Rendering.PostProcessing;
using MoreMountains.Feedbacks;
using MoreMountains.TopDownEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

namespace MoreMountains.FeedbacksForThirdParty
{
    
    /// <summary>
    /// Handles the earthquake, falling object calls, effects, information, etc.
    /// </summary>

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

        public string textToDisplay3;
        public GameObject tablecheck;
        public GameObject fallingLights;
        public GameObject enableDoors;
        public GameObject objective;
        
        public bool tableFlag = true;
        public bool cheatQuake = false;
        
        private string sceneName;

        public GameObject dustStormPrefab;

        // TODO Move these into a separate object
        private GameObject[] doors;
        private Rigidbody[] bodies;
        private BoxCollider[] colliders;
        private Clobberer[] clobberers;
        
        // Start is called before the first frame update
        void Start()
        {
            //lightRB= light1.GetComponent<Rigidbody>();
            tableFlag = true;
            StartCoroutine(QuakeDown());
            Scene currentScene = SceneManager.GetActiveScene ();
            sceneName = currentScene.name;
            doors = GameObject.FindGameObjectsWithTag("Door");
            bodies = Array.ConvertAll(doors, d => d.GetComponent(typeof(Rigidbody)) as Rigidbody);
            colliders = Array.ConvertAll(doors, d => d.GetComponent(typeof(BoxCollider)) as BoxCollider);

            clobberers = Array.ConvertAll(doors, d => d.GetComponent(typeof(Clobberer)) as Clobberer);
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown("p"))
            {
               QuakeTrigger();
               cheatQuake = true;
            }

            if (string.Compare(sceneName, "Level 2") == 0)
            {
               if (objective.GetComponent<UpdateQuests>().shelterBool)
               {
                   EventTracker.GetComponent<InformationCanvas>().DisplayInfo(textToDisplay3);
               }
            }
        }
        
        

        public IEnumerator QuakeDown()
        {
           yield return new WaitForSeconds(15f);
           if (cheatQuake == false)
           {
               QuakeTrigger();   
           }

           //yield return new WaitForSeconds(10f);
           //InfoEnabler.SetActive(false);
           //EventTracker.GetComponent<InformationCanvas>().DisplayInfo(textToDisplay2);
          // enableDoors.SetActive(false);
        }

        public IEnumerator FlapDoors(float duration)
        {
            while (duration > 0)
            {
                Vector3 kick = Random.onUnitSphere * 1;
                foreach (Rigidbody b in bodies)
                {
                    b.AddRelativeForce(kick, ForceMode.Impulse);
                }
                yield return new WaitForSeconds(0.25f);
                duration -= 0.25f;
            }
        }
        
        public IEnumerator ShakeIt()
        {

           Instantiate(dustStormPrefab, new Vector3(100, 10, -65), Quaternion.identity);
            foreach (Clobberer c in clobberers)
            {
                c.enabled = true;
            }

            while (tableFlag)
            {
                my_camera.GetComponent<MMCinemachineCameraShaker>().ShakeCamera(duration, amplitude, frequency);
                StartCoroutine(FlapDoors(duration));
                yield return new WaitForSeconds(duration);
            }
            foreach (Clobberer c in clobberers)
            {
                c.enabled = false;
            }
            EventTracker.GetComponent<InformationCanvas>().DisplayInfo(textToDisplay2);
            enableDoors.SetActive(false);

        }
        
        
        

        private void QuakeTrigger()
        {
            InfoEnabler.SetActive(true);
            EventTracker.GetComponent<InformationCanvas>().DisplayInfo(textToDisplay1);
            StartCoroutine(ShakeIt());
            tablecheck.SetActive(true);
           // my_camera.GetComponent<MMCinemachineCameraShaker>().ShakeCamera(duration, amplitude, frequency);
           if (string.Compare(sceneName, "Level 1") ==0)
           {
               my_bookshelf.GetComponent<MyFallingObject>().Fall();
           }
           fallingLights.GetComponent<QuakeFurniture>().Drop();

        }
    }
}
