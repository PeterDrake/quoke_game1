using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StatusManager : MonoBehaviour, IPauseable 
{
    // Start is called before the first frame update

    public static StatusManager Manager;

    public Slider HydrationSlider;
    public Slider ReliefSlider;
    public Slider WarmthSlider;
    
    [MoreMountains.Tools.ReadOnly] public float Hydration;
    [MoreMountains.Tools.ReadOnly] public float Relief;
    [MoreMountains.Tools.ReadOnly] public float Warmth;

    
    [Header("Time (in seconds) to deplete the entire resource")]
    public float HydrationDepletionTime = 180f;
    public float ReliefDepletionTime = 240f;
    public float WarmthDepletionTime = 300f;

    [Header("Loss is applied once every second")]
    [MoreMountains.Tools.ReadOnly][Min(0)] public float HydrationLossRate;
    [MoreMountains.Tools.ReadOnly][Min(0)] public float ReliefLossRate;
    [MoreMountains.Tools.ReadOnly][Min(0)] public float WarmthLossRate;
    
    public bool DegradeHydration = true;
    public bool DegradeRelief = true;
    public bool DegradeWarmth = true; 
    
    private bool hydrationChanged;
    private bool reliefChanged;
    private bool warmthChanged;
    
    private float HydrationMax = 100f;
    private float ReliefMax = 100f;
    private float WarmthMax = 100f;
    
    private bool enabled = true;
    private bool Degrading = true;
    private const float DEGRADETIME = 1f;
    
    
    void Start()
    {
        if (StatusManager.Manager == null) StatusManager.Manager = this;
        else Destroy(this);
        
        Hydration = HydrationMax;
        Relief = ReliefMax;
        Warmth = WarmthMax;

        HydrationSlider.maxValue = HydrationMax;
        ReliefSlider.maxValue = ReliefMax;
        WarmthSlider.maxValue = WarmthMax;

        HydrationLossRate = HydrationMax / HydrationDepletionTime;
        ReliefLossRate = ReliefMax / ReliefDepletionTime;
        WarmthLossRate = WarmthMax / WarmthDepletionTime;

        StartCoroutine(DegradeStatus());
    }

    // Update is called once per frame
    private void Update()
    {
        if (!enabled) return;

        if (Hydration <= 0)
        {
            enabled = false;
            Death.Manager.PlayerDeath("Dehydration Death :(");
        }
        else if (Relief <= 0)
        {
            enabled = false;
            Death.Manager.PlayerDeath("Constipation Death :(");
        }
        else if (Warmth <= 0)
        {
            enabled = false;
            Death.Manager.PlayerDeath("Hypothermia Death :(");
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

    public bool Paused => enabled;


    public void Pause()
    {
        enabled = true;
        Degrading = false;
    }
    
    public void Unpause()
    {
        enabled = true;
        if(!Degrading) StartCoroutine(DegradeStatus());
    }
}
