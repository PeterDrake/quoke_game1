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
        
        [Header("Admin Tools")]
        public bool adminMode = true;
        public bool showCountdown = true;
        [Space]
        
        public float TimeBeforeQuake = 15f;
        public float AftershockTime = 10f;
        
        private float entranceGracePeriod = 2f;
        private float timeTillQuake;
        
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


        [HideInInspector] public bool Quaking;
        private byte quakes; //times quaked 

        private bool InQuakeZone;
        private bool CountdownFinished;
        
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
            StartCoroutine(nameof(QuakeCountdown),TimeBeforeQuake);

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

            if (!cheatQuake && !Quaking && InQuakeZone && CountdownFinished || (adminMode && Input.GetKeyDown("p")))
            {
                TriggerQuake();   
            }

            if (haveObjective && !textDisplayed && quests.shelterBool)
            {
                textDisplayed = true;
                _informationCanvas.DisplayInfo(textToDisplay3);
            }
        }

        public void TriggerCountdown(float time)
        {
            CountdownFinished = false;
            StopCoroutine(nameof(QuakeCountdown));
            StartCoroutine(nameof(QuakeCountdown), time);
        }

        private IEnumerator QuakeCountdown(float CountdownTime)
        {
            timeTillQuake = CountdownTime;
            while (timeTillQuake > 0)
            {
                yield return new WaitForSeconds(1f);
                timeTillQuake--;
                if (showCountdown) Debug.Log("Time Till Quake: " + timeTillQuake);
            }
            CountdownFinished = true;
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
            Instantiate(dustStormPrefab, new Vector3(100, 10, -65), Quaternion.identity);
            
            foreach (Clobberer c in clobberers)
            {
                c.enabled = true;
            }

            var cam = my_camera.GetComponent<MMCinemachineCameraShaker>();
            while (Quaking)
            {
                cam.ShakeCamera(duration, amplitude, frequency, false);
                StartCoroutine(FlapDoors(duration));
                yield return new WaitForSeconds(duration);
            }
            foreach (Clobberer c in clobberers)
            {
                c.enabled = false;
            }
            _informationCanvas.DisplayInfo(textToDisplay2);
            
            enableDoors.SetActive(false);
            
            quakes++;
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
            if (!Quaking || quakes > 0) return;
            Debug.Log("Stop Quake Called"+Quaking);
            Quaking = false;
            TriggerCountdown(AftershockTime);
        }

        public void PlayerInQuakeZone(bool status)
        {
            if (status && (CountdownFinished || timeTillQuake < entranceGracePeriod) && (InQuakeZone != status))
                TriggerCountdown(entranceGracePeriod);
            
            InQuakeZone = status;
        }
    }
}
