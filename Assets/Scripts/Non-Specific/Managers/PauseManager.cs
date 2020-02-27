using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public static PauseManager Instance;
    
    private bool paused;
    
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(this);
        
    }
    public bool Pause(bool val)
    {
        if (val)
        {
            Time.timeScale = 0;
            paused = true;
            return true;
        }
        
        Time.timeScale = 1f;
        paused = false;
        return false;
    }
}