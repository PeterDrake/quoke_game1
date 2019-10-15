using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gasCountdown : MonoBehaviour
{
    /// <summary>
    /// countdown for gas explosion. Starts after talking to NPC. players has x seconds to turn off the gas before they die
    /// </summary>
    ///
    private bool gasTriggered = false;

    public void OnTriggerExit(Collider other)
    {
        if (!gasTriggered && other.CompareTag("Player"))
        {
            gasTriggered = true;
            StartCoroutine(gasExplosion());
        }
    }

    public IEnumerator gasExplosion()
    {
        // this number controls time until explosion
        yield return new WaitForSeconds(15f);
        Death.Manager.PlayerDeath("YOU DIED OF A GAS EXPLOSION :(");
    }
}
