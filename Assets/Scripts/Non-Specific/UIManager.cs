using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(this);
    }

    private UIElement activeWindow;
    private UIElement previousWindow;

    public void Initialize(UIElement active)
    {
        activeWindow = active;
        active.Open();
    }
    
    public void SetAsActive(UIElement newActive)
    {
        if (activeWindow == null)
        {
            Initialize(newActive);
            return;
        }
        
        if (!newActive.Force() && activeWindow.IsLocked()) return;

        if (newActive != activeWindow)
        {
            previousWindow = activeWindow;
            previousWindow.Close();
            activeWindow = newActive;
        }

        activeWindow.Open();
    }

    public void ToggleActive(UIElement newActive)
    {
        if (newActive == activeWindow)
        {
            ActivatePrevious();
        }
        else
        {
            SetAsActive(newActive);
        }
    }

    public void ActivatePrevious()
    {
        activeWindow.Close();
        previousWindow.Open();
        
        UIElement temp = activeWindow;
        activeWindow = previousWindow;
        previousWindow = temp;
    }
}
