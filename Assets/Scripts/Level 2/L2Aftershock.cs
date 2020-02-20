using System.Collections;
using System.Collections.Generic;
using MoreMountains.FeedbacksForThirdParty;
using UnityEngine;

public class L2Aftershock : MonoBehaviour
{
    public ObjectDropper objectDropper;
    public void Start()
    {
        QuakeManager.Instance.OnQuake.AddListener(OnQuake);
    }

    private void OnQuake()
    {
        if (QuakeManager.Instance.quakes > 0)
        {
            Logger.Instance.Log("Aftershock Started");
            Death.Manager.PlayerDeath("The house collapsed in an aftershock!");
            objectDropper.Drop();
        }
    }
}
