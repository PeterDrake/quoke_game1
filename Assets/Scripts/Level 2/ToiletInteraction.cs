using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletInteraction : MonoBehaviour
{
    private bool _firstInteraction = true;
    
    private InteractWithObject _interact;
    private void Start()
    {
        _interact = GetComponent<InteractWithObject>();
    }

    public void Interaction()
    {
        Systems.Status.AffectRelief(100);
        _firstInteraction = false;
        _interact.SetInteractText("Press 'E' to Use Toilet");
        _interact.DeleteItems();
        _interact = null;
        }
    }

