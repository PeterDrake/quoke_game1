using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StatusManager : MonoBehaviour
{
    // Start is called before the first frame update

    public static StatusManager Manager; 
     
    public float HydrationMax;
    public float ReliefMax;
    public float WarmthMax;

    public Slider HydrationSlider;
    public Slider ReliefSlider;
    public Slider WarmthSlider;
    
    [SerializeField][ReadOnly] private float Hydration;
    [SerializeField][ReadOnly] private float Relief;
    [SerializeField][ReadOnly] private float Warmth;
    
    
    [Header("Loss is applied once every second")]
    [Min(0)] public float HydrationLossRate;
    [Min(0)] public float SanitationLossRate;
    [Min(0)] public float ExposureLossRate;
    
    
    /*[MoreMountains.Tools.ReadOnly] public float HydrationDeathTime = 0;
    [MoreMountains.Tools.ReadOnly] public float SanitationDeathTime = 0;
    [MoreMountains.Tools.ReadOnly] public float ExposureDeathTime = 0;*/

    
    //hydration first, then relief then warmth
    //3, 4, 5 mins
    public bool DegradeHydration = true;
    public bool DegradeRelief = true;
    public bool DegradeWarmth = true; 
    
    private bool hydrationChanged;
    private bool reliefChanged;
    private bool warmthChanged;
    
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

        /*HydrationDeathTime = HydrationMax / HydrationLossRate;
        ExposureDeathTime = WarmthMax / ExposureLossRate;
        SanitationDeathTime = ReliefMax / SanitationLossRate;*/
        
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

        if (DegradeRelief && SanitationLossRate > 0)
        {
            Relief -= SanitationLossRate;
            reliefChanged = true;
        }

        if (DegradeWarmth && ExposureLossRate > 0)
        {
            Warmth -= ExposureLossRate;
            warmthChanged = true;
        }

        yield return new WaitForSeconds(DEGRADETIME);
        StartCoroutine(DegradeStatus());
    }

    public void Pause()
    {
        enabled = false;
        Degrading = false;
    }
    
    public void Unpause()
    {
        enabled = true;
        if(!Degrading) StartCoroutine(DegradeStatus());
    }
}
