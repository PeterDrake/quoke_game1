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
    [Min(0)] public float HydrationLoss;
    [Min(0)] public float ReliefLoss;
    [Min(0)] public float WarmthLoss;

    
    public bool DegradeHydration = true;
    public bool DegradeRelief = true;
    public bool DegradeWarmth = true; 
    
    private bool hydrationChanged;
    private bool reliefChanged;
    private bool warmthChanged;
    
    private bool enabled = true;
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
        if (DegradeHydration && HydrationLoss > 0)
        {
            Hydration -= HydrationLoss;
            hydrationChanged = true;
        }

        if (DegradeRelief && ReliefLoss > 0)
        {
            Relief -= ReliefLoss;
            reliefChanged = true;
        }

        if (DegradeWarmth && WarmthLoss > 0)
        {
            Warmth -= WarmthLoss;
            warmthChanged = true;
        }

        yield return new WaitForSeconds(DEGRADETIME);
        StartCoroutine(DegradeStatus());
    }
}
