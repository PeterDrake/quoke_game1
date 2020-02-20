using UnityEngine;

/// <summary>
/// Ensures that only one window will be active on the UI at any given moment
/// </summary>
public class UIManager : MonoBehaviour
{
    // public static reference so other scripts can easily reference this
    public static UIManager Instance;

    private bool initialized;
    
    public void Awake() 
    {
        // Singleton Pattern -> only one can exist at any given time
        if (Instance == null) Instance = this;
        else Destroy(this);
    }

    private UIElement activeWindow; // Currently displayed window
    private UIElement previousWindow; // window displayed before active
    
    
    /// <summary>
    /// opens newActive and closes the current active window
    /// </summary>
    /// <param name="newActive"></param>
    public void SetAsActive(UIElement newActive)
    {
        if (!initialized)
        {
            Initialize(newActive);
            return;
        }

        if (newActive == activeWindow)
        {
            activeWindow.Open();
            return;
        }
        
        if (!newActive.Force() && activeWindow.IsLocked()) return;
        
        previousWindow = activeWindow;
        previousWindow.Close();
        activeWindow = newActive;
        activeWindow.Open();
    }
    
    public void Initialize(UIElement active)
    {
        activeWindow = active;
        active.Open();
        initialized = true;
    }

    /// <summary>
    /// if newActive is currently active it will be closed, otherwise it will be opened
    /// </summary>
    /// <param name="newActive"></param>
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
    
    /// <summary>
    /// Close the current window and go back to the last one
    /// </summary>
    public void ActivatePrevious()
    {
        activeWindow.Close();
        previousWindow.Open();
        
        UIElement temp = activeWindow;
        activeWindow = previousWindow;
        previousWindow = temp;
    }
}
