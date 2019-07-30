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

        // Start is called before the first frame update
        void Start()
        {
            //lightRB= light1.GetComponent<Rigidbody>();
            tableFlag = true;
            StartCoroutine(QuakeDown());
            Scene currentScene = SceneManager.GetActiveScene ();
            sceneName = currentScene.name;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown("p"))
            {
               QuakeTrigger();
               cheatQuake = true;
            }

            if (objective.GetComponent<UpdateQuests>().shelterBool)
            {
                EventTracker.GetComponent<InformationCanvas>().DisplayInfo(textToDisplay3);
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

        private void FlapDoors(float duration)
        {
            Debug.Log("Commencing flap!");
            GameObject[] doors = GameObject.FindGameObjectsWithTag("Door");
            Rigidbody[] bodies = Array.ConvertAll(doors, d => d.GetComponent(typeof(Rigidbody)) as Rigidbody);
            Debug.Log("Bodies: " + bodies);
            while (duration > 0)
            {
                Debug.Log("Flap.");
                Vector3 kick = Random.onUnitSphere;
                foreach (Rigidbody b in bodies)
                {
                    b.AddRelativeForce(kick);
                }
                duration -= 1;
            }
        }
        
        public IEnumerator ShakeIt()
        {
            Instantiate(dustStormPrefab, new Vector3(100, 10, -65), Quaternion.identity);
 
            while (tableFlag)
            {
                my_camera.GetComponent<MMCinemachineCameraShaker>().ShakeCamera(duration, amplitude, frequency);
                FlapDoors(duration);
                yield return new WaitForSeconds(duration);
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
