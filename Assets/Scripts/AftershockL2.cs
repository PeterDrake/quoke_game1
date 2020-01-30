using System.Collections;
using System.Collections.Generic;
using MoreMountains.FeedbacksForThirdParty;
using UnityEngine;

public class AftershockL2 : MonoBehaviour
{
    public void TriggerOnQuake()
    {
        if (QuakeManager.Instance.quakes > 0)
        {
            Death.Manager.PlayerDeath("The house collapsed due to an after shock!");
        }
    }
}
