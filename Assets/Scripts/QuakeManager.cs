using System;
using System.Collections;
using System.Linq.Expressions;
using MoreMountains.Tools;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

namespace MoreMountains.FeedbacksForThirdParty
{
    
    /// <summary>
    /// Handles the earthquake, falling object calls, effects, information, etc.
    /// </summary>

    public class QuakeManager : MonoBehaviour
    {
        public static QuakeManager Instance;
        
        public bool adminMode = true;
        public float TimeBeforeQuake = 15f;
        
        public GameObject my_camera;
        public float amplitude;
        public float frequency;
        public float duration;
        

        public GameObject EventTracker;
        public String textToDisplay1;

        public string textToDisplay2;

        public string textToDisplay3;
        public GameObject fallingLights;
        public GameObject enableDoors;
        public GameObject objective;
        
        public bool tableFlag = true;
        public bool cheatQuake = false;
        
        public GameObject dustStormPrefab;

        private bool haveObjective;
        private bool textDisplayed;
        private UpdateQuests quests;

        // TODO Move these into a separate object
        private GameObject[] doors;
        private Rigidbody[] bodies;
        private BoxCollider[] colliders;
        private Clobberer[] clobberers;


        public bool Quaking;
        
        
        /*Subscribed to onQuake:
            QuakeFurniture
            Bookcase
            
         
         */
        public UnityEvent OnQuake;

        private InformationCanvas _informationCanvas; 
        // Start is called before the first frame update

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(this);
            
            tableFlag = true;
        }

        void Start()
        {
            StartCoroutine(QuakeCountdown());

            doors = GameObject.FindGameObjectsWithTag("Door");
            bodies = Array.ConvertAll(doors, d => d.GetComponent(typeof(Rigidbody)) as Rigidbody);
            colliders = Array.ConvertAll(doors, d => d.GetComponent(typeof(BoxCollider)) as BoxCollider);
            clobberers = Array.ConvertAll(doors, d => d.GetComponent(typeof(Clobberer)) as Clobberer);
            
            
            if (objective != null) quests = objective.GetComponent<UpdateQuests>();

            _informationCanvas = EventTracker.GetComponent<InformationCanvas>();
        }

        // Update is called once per frame
        void Update()
        {
            if (adminMode && Input.GetKeyDown("p"))
            {
                cheatQuake = true;
                TriggerQuake();
               
            }

            if (haveObjective && !textDisplayed && quests.shelterBool)
            {
                textDisplayed = true;
                _informationCanvas.DisplayInfo(textToDisplay3);
            }
        }
        
        

        private IEnumerator QuakeCountdown()
        {
           yield return new WaitForSeconds(TimeBeforeQuake);
           if (!cheatQuake)
           {
               TriggerQuake();   
           }
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
        
        private IEnumerator ShakeIt()
        {
            Debug.Log("Started");
            Instantiate(dustStormPrefab, new Vector3(100, 10, -65), Quaternion.identity);
            foreach (Clobberer c in clobberers)
            {
                c.enabled = true;
            }

            while (Quaking)
            {
                my_camera.GetComponent<MMCinemachineCameraShaker>().ShakeCamera(duration, amplitude, frequency, false);
                StartCoroutine(FlapDoors(duration));
                yield return new WaitForSeconds(duration);
            }
            foreach (Clobberer c in clobberers)
            {
                c.enabled = false;
            }
            _informationCanvas.DisplayInfo(textToDisplay2);
            
            enableDoors.SetActive(false);
        }

        public void TriggerQuake()
        {
            if(Quaking) return;
            Quaking = true;
            
            StopAllCoroutines();
            OnQuake.Invoke();

            _informationCanvas.DisplayInfo(textToDisplay1);
            
            StartCoroutine(ShakeIt());
            //other methods that used to be called here are called from OnQuake instead
        }

        public void StopQuake()
        {
            Debug.Log("Stop Quake Called"+Quaking);
            Quaking = false;
        }
    }
}
