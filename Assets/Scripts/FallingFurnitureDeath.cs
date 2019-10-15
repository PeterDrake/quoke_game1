using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FallingFurnitureDeath : MonoBehaviour
{
    /// <summary>
    /// When a piece of furniture falls on the player from the quake it kills them.
    /// after it hits the ground ~1.5f it will disable the ability to kill
    /// </summary>

    private bool isEnabled = true;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        StartCoroutine(DontKill());
    }

    private IEnumerator DontKill()
    {
        yield return new WaitForSeconds(1.5f);
        isEnabled = false;
        rb.isKinematic = true;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (isEnabled && other.gameObject.CompareTag("Player"))
        {
            Death.Manager.PlayerDeath("Crushed by falling object");
        }
    }
}
