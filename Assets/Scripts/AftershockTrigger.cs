using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.FeedbacksForThirdParty;
using UnityEngine;

public class AftershockTrigger : MonoBehaviour
{

    public InformationCanvas _canvas;
    private void OnTriggerEnter(Collider other)
    {
        QuakeManager.Instance.TriggerCountdown(2f);
        _canvas.DisplayInfo("Have a look around...");
        Logger.Instance.Log("Player has left the house");
        Destroy(gameObject);
    }
}
