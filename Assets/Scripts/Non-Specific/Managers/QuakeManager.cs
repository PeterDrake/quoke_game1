using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

/// <summary>
/// Handles the earthquake, falling object calls, effects, information, etc.
/// </summary>
public class QuakeManager : MonoBehaviour
{
    public static QuakeManager Instance;
    
    [Header("Admin Tools")]
    [SerializeField] private bool adminMode = true;
    [SerializeField] private bool showCountdown = true;
    [Space]
    [Space]
    
    [Tooltip("How long after starting before the earthquake goes off?")]
    [SerializeField] private float TimeBeforeQuake = 15f;
    
    [Tooltip("How long after the first quake before aftershock?")]
    [SerializeField] private float AftershockTime = 10f;
    
    //----Camera Shake Options---
    [Header("Camera Shake Options")]
    [SerializeField] private MoreMountains.FeedbacksForThirdParty.MMCinemachineCameraShaker camera;
    [SerializeField] private float amplitude;
    [SerializeField] private float frequency;
    [SerializeField] private float duration;
    //--------------------
    
    
    [TextArea][SerializeField] private string textOnQuake;
    [TextArea][SerializeField] private string textAfterQuake;

    // Game object which will be disabled after quake
    [SerializeField] private GameObject enableDoors;

    [SerializeField] private GameObject dustStormPrefab;

    // TODO Move these into a separate object
    private GameObject[] doors;
    private Rigidbody[] bodies;
    private Clobberer[] clobberers;


    [HideInInspector] public bool Quaking;

    [MoreMountains.Tools.ReadOnly] public byte quakes; //times quaked 
    

    private bool _inQuakeZone; // is player in a zone where the quake can happen?
    [MoreMountains.Tools.ReadOnly] public bool _inSafeZone; // is the player safe (under the table)?
    
    private bool _countdownFinished;
    private float entranceGracePeriod = 2f;
    private float _timeTillQuake;
    
    [SerializeField] private float _minimumShakes = 1; //each shake is 'duration' (5) seconds long
    private bool quakeOverride;


    /*Subscribed to onQuake:
        QuakeFurniture
        Bookcase
     */
    // scripts can 'subscribe' to this Event to have their functions called when the earthquake begins
    public UnityEvent OnQuake; 

    private InformationCanvas _informationCanvas;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }

    private void Start()
    {
        StartCoroutine(nameof(QuakeCountdown), TimeBeforeQuake);

        doors = GameObject.FindGameObjectsWithTag("Door");
        bodies = Array.ConvertAll(doors, d => d.GetComponent(typeof(Rigidbody)) as Rigidbody);
        clobberers = Array.ConvertAll(doors, d => d.GetComponent(typeof(Clobberer)) as Clobberer);

        _informationCanvas = GameObject.Find("Canvi").transform.Find("GUI").GetComponent<GuiDisplayer>().GetBanner();
    }

    void Update()
    {
        if ((_countdownFinished && !Quaking && (quakeOverride || _inQuakeZone)) || (adminMode && Input.GetKeyDown("p")) )
        {
            TriggerQuake();   
        }
    }

    // Starts a countdown of 'time' seconds. When the countdown finishes, the earthquake will happen
    public void TriggerCountdown(float time)
    {
        _countdownFinished = false;
        StopCoroutine(nameof(QuakeCountdown));
        StartCoroutine(nameof(QuakeCountdown), time);
    }

    // the actual countdown
    private IEnumerator QuakeCountdown(float CountdownTime)
    {
        _timeTillQuake = CountdownTime;
        while (_timeTillQuake > 0)
        {
            yield return new WaitForSeconds(1f);
            _timeTillQuake--;
            if (showCountdown) Debug.Log("Time Till Quake: " + _timeTillQuake);
        }
        _countdownFinished = true;
    }

    // flaps  each o the doors for the given duration
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
    
    // everything that happens during the earthquake
    private IEnumerator ShakeIt()
    {
        Instantiate(dustStormPrefab, new Vector3(100, 10, -65), Quaternion.identity);
        
        foreach (Clobberer c in clobberers)
        {
            c.enabled = true;
        }
        
        int shakes = 0;
        while (true)
        {
            camera.ShakeCamera(duration, amplitude, frequency, false);
            StartCoroutine(FlapDoors(duration));
            yield return new WaitForSeconds(duration);
            // if the player is in the safezone, and the earthquake has gone long enough, stop it 
            if (_inSafeZone && shakes >= _minimumShakes)
            {
                break;
            }

            shakes++;
        }
        
        StopQuake();
        foreach (Clobberer c in clobberers)
        {
            c.enabled = false;
        }
        _informationCanvas.ChangeText(textAfterQuake);
        
        enableDoors.SetActive(false); // allow player to exit house
        
        quakes++;
    }

    public void TriggerQuake()
    {
        if(Quaking) return;
        Systems.Status.Pause();
        
        Quaking = true;
        Logger.Instance.Log((quakes == 0 ? "Earthquake" : "Aftershock")+" triggered!");
        StopAllCoroutines();
        
        OnQuake.Invoke(); // every function subscribed to OnQuake is called here

        _informationCanvas.ChangeText(textOnQuake);
        
        StartCoroutine(ShakeIt());
    }

    public void StopQuake()
    {
        if (!Quaking || quakes > 0) return;
        Logger.Instance.Log("Quake Stopped");
        
        Quaking = false;
        Systems.Status.Pause();
        TriggerCountdown(AftershockTime);
    }

    public void InSafeZone(bool status)
    {
        _inSafeZone = status;
    }

    public void PlayerInQuakeZone(bool status)
    {
        if (quakes > 0 && status == false)
        {
            TriggerCountdown(entranceGracePeriod);
        }
        if (status && (_countdownFinished || _timeTillQuake < entranceGracePeriod) && (_inQuakeZone != status))
            TriggerCountdown(entranceGracePeriod);
        
        _inQuakeZone = status;
    }

    public void ManualTriggerAftershock(float gracePeroid)
    {
        if (quakes > 0)
        {
            quakeOverride = true;
            TriggerCountdown(gracePeroid);
        }
    }
}

