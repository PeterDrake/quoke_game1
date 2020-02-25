using System;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public static PauseManager Instance;

    private List<Pauseable> pauseAgents;
    private bool paused;
    
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(this);
        
        pauseAgents = new List<Pauseable>();
    }

    public void Register(Pauseable agent)
    {
        pauseAgents.Add(agent);
    }

    public bool Pause(bool val)
    {
        if (val && !paused)
        {
            Pause();
            return true;
        }
        
        if (paused)
        {
            UnPause();
        }
        return false;
    }

    public void Pause()
    {
        if (paused) return;
        paused = true;
        foreach (Pauseable pauseAgent in pauseAgents)
        {
            pauseAgent.Pause();
        }
    }

    public void UnPause()
    {
        if (!paused) return;
        paused = false;
        
        foreach (Pauseable pauseAgent in pauseAgents)
        {
            pauseAgent.UnPause();
        }
    }
    
}