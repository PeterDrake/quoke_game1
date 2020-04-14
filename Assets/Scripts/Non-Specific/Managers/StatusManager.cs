﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Tools = MoreMountains.Tools;

/// <summary>
/// Manages the three resources, Hydration, Relief, and Warmth, their associated sliders,
/// and killing the player when one runs out
/// </summary>
public class StatusManager : MonoBehaviour
{
    [SerializeField] private Slider HydrationSlider;
    [SerializeField] private Slider ReliefSlider;
    [SerializeField] private Slider WarmthSlider;
    [SerializeField] private DeathDisplay deathDisplay;
    [SerializeField] private Image WaterRefill;
    [SerializeField] private Image ReliefRefill;
    [SerializeField] private Image WarmthRefill;
    [SerializeField] private Color refillColor;

    [Tools.ReadOnly] public float Hydration;
    [Tools.ReadOnly] public float Relief;
    [Tools.ReadOnly] public float Warmth;

    [Header("Time (in seconds) to deplete the entire resource")]
    [SerializeField] private float HydrationDepletionTime = 180f;
    [SerializeField] private float ReliefDepletionTime = 240f;
    [SerializeField] private float WarmthDepletionTime = 300f;

    [Header("Loss is applied once every second")]
    [Tools.ReadOnly][Min(0)] public float HydrationLossRate;
    [Tools.ReadOnly][Min(0)] public float ReliefLossRate;
    [Tools.ReadOnly][Min(0)] public float WarmthLossRate;
    
    [SerializeField] private bool DegradeHydration = true;
    [SerializeField] private bool DegradeRelief = true;
    [SerializeField] private bool DegradeWarmth = true; 
    
    private bool hydrationChanged;
    private bool reliefChanged;
    private bool warmthChanged;
    
    private float HydrationMax = 100f;
    private float ReliefMax = 100f;
    private float WarmthMax = 100f;
    
    private bool enabled = true;
    private bool alive;
    private bool Degrading = true;
    private const float DEGRADETIME = 1f;

    private Color HydrationBar;
    private Color ReliefBar;
    private Color WarmthBar;

    private void Start()
    {

        Hydration = HydrationMax;
        Relief = ReliefMax;
        Warmth = WarmthMax;

        HydrationSlider.maxValue = HydrationMax;
        ReliefSlider.maxValue = ReliefMax;
        WarmthSlider.maxValue = WarmthMax;

        HydrationLossRate = HydrationMax / HydrationDepletionTime;
        ReliefLossRate = ReliefMax / ReliefDepletionTime;
        WarmthLossRate = WarmthMax / WarmthDepletionTime;

        StartCoroutine(nameof(DegradeStatus),DegradeStatus());

        HydrationBar = HydrationSlider.image.color;
        ReliefBar = ReliefSlider.image.color;
        WarmthBar = WarmthSlider.image.color;

        alive = true;
    }

    // Update is called once per frame
    private void Update()
    {
        if (!enabled) return;

        if (Hydration <= 0)
        {
            PlayerDeath("Dehydration Death :(");
        }
        else if (Relief <= 0)
        {
            PlayerDeath("Due to lack of a proper toilet, you were forced to defecate without proper " +
                                      "sanitation. You caught a disease and died.");
        }
        else if (Warmth <= 0)
        {
            PlayerDeath("Hypothermia Death :(");
        }

        if (Hydration <= 90)
        {
            HydrationSlider.image.color = Color.Lerp(HydrationBar, Color.blue, Mathf.PingPong(Time.time, .5f));
        }
        if (Relief <= 90)
        {
            ReliefSlider.image.color = Color.Lerp(ReliefBar, new Color(.2f,1f, .1f, 1), Mathf.PingPong(Time.time, .5f));
        }
        if (Warmth <= 90)
        {
            WarmthSlider.image.color = Color.Lerp(WarmthBar, Color.red, Mathf.PingPong(Time.time, .5f));
        }


        if (hydrationChanged)
        {
            hydrationChanged = false;
            HydrationSlider.value = Hydration;
        }
        if (reliefChanged)
        {
            reliefChanged = false;
            ReliefSlider.value = Relief;
        }
        if (warmthChanged)
        {
            warmthChanged = false;
            WarmthSlider.value = Warmth;
        }

        RefillMeter();
    }

    public void AffectHydration(float deltaH)
    {
        Hydration += deltaH;
        if (Hydration > HydrationMax) Hydration = HydrationMax;
        hydrationChanged = true;
    }
    public void AffectRelief(float deltaR)
    {
        Relief += deltaR;
        if (Relief > ReliefMax) Relief = ReliefMax;
        reliefChanged = true;
    }
    public void AffectWarmth(float deltaW)
    {
        Warmth += deltaW;
        if (Warmth > WarmthMax) Warmth = WarmthMax;
        warmthChanged = true;
    }

    public float GetHydration()
    {
        return Hydration;
    }
    
    public float GetRelief()
    {
        return Relief;
    }
    
    public float GetWarmth()
    {
        return Warmth;
    }
    
    public void PlayerDeath(string textOnDeath)
    {
        if (!alive) return;
        alive = false;
        Logger.Instance.Log("Player killed by: "+textOnDeath);
        deathDisplay.Activate(textOnDeath);
    }
    
    public bool Paused => !enabled;


    public void Pause()
    {
        if(enabled) StopCoroutine(nameof(DegradeStatus));
        enabled = false;
    }
    

    public void UnPause()
    {
        var c = enabled;
        enabled = true;
        if(!c) StartCoroutine(nameof(DegradeStatus), DegradeStatus());
    }

    private IEnumerator DegradeStatus()
    {
        if (!enabled) yield break;
        if (DegradeHydration && HydrationLossRate > 0)
        {
            Hydration -= HydrationLossRate;
            hydrationChanged = true;
        }

        if (DegradeRelief && ReliefLossRate > 0)
        {
            Relief -= ReliefLossRate;
            reliefChanged = true;
        }

        if (DegradeWarmth && WarmthLossRate > 0)
        {
            Warmth -= WarmthLossRate;
            warmthChanged = true;
        }

        yield return new WaitForSeconds(DEGRADETIME);
        StartCoroutine(DegradeStatus());
    }

    public void RefillMeter()
    {
        if (Hydration == 100)
        {
            WaterRefill.color = refillColor;
        }
        else if (Relief == 100)
        {
            ReliefRefill.color = refillColor;
        }
        else if (Warmth == 100)
        {
            WarmthRefill.color = refillColor;
        }
        else
        {
            WaterRefill.color = Color.Lerp(WaterRefill.color, Color.clear, Time.deltaTime);
            ReliefRefill.color = Color.Lerp(ReliefRefill.color, Color.clear, Time.deltaTime);
            WarmthRefill.color = Color.Lerp(WarmthRefill.color, Color.clear, Time.deltaTime);
        }

    }
}
