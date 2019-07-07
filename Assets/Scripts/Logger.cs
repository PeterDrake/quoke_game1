using UnityEngine;
using System;

public static class Logger
{
    // Start is called before the first frame update
    public static void Log(string message)
    {
        int time = (int)Math.Round(Time.realtimeSinceStartup);
        Debug.Log(time + ": " + message);
    }
    
}
