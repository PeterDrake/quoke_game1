using UnityEngine;
using System;
using System.IO;
using System.Net.NetworkInformation;
using MoreMountains.Tools;

public class Logger : Singleton<Logger>
{
    private StreamWriter writer;

    private const bool DoLog = false; // change to true if you want logging
    
    
    public void Log(string message)
    {
        if (!DoLog) return;
        
        int time = (int)Math.Round(Time.realtimeSinceStartup);
        writer.WriteLine(time + ": " + message);
        Debug.Log(time + ": " + message);
    }

    protected void Awake()
    {
        if (!DoLog) return;
        
        base.Awake();
        writer = new StreamWriter(GenerateFileName());
        Log("Game started.");
    }

    protected void OnApplicationQuit()
    {
        if (!DoLog) return;
        
        Log("Game ended.");
        writer.Close();
    }

    // Generates a name for the log file
    private string GenerateFileName()
    {
        return "QuokeLogFiles/" + GetMacAddress() + "_" + DateTime.Now.ToString("yyyyMMdd-HHmmss") + ".log";
    }
    
    // Adapted from http://www.independent-software.com/getting-local-machine-mac-address-in-csharp.html/ 
    private string GetMacAddress()
    {
        foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
        {
            if (nic.NetworkInterfaceType != NetworkInterfaceType.Ethernet && nic.NetworkInterfaceType != NetworkInterfaceType.Wireless80211)
            {
                continue;
            }
            if (nic.OperationalStatus == OperationalStatus.Up)
            {
                return nic.GetPhysicalAddress().ToString();
            }
        }
        throw new Exception("No MAC address found");
    }
    
}
