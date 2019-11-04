using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.FeedbacksForThirdParty;
using UnityEngine;

public class AftershockTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        QuakeManager.Instance.TriggerCountdown(2f);
        Destroy(gameObject);
    }
}
