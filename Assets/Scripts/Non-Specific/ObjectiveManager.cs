using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;

public class ObjectiveManager : MonoBehaviour
{
    public static ObjectiveManager Instance;
    public delegate void Callback();

    [SerializeField] private Dictionary<String, bool> events;
    private Dictionary<String, LinkedList<Callback>> callbacks;


    private void Awake()
    {
        // singleton structure
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
            
        callbacks = new Dictionary<string, LinkedList<Callback>>();
        events = new Dictionary<string, bool>();
    }

    public bool Register(String key, Callback cb=null)
    {
        if (events.ContainsKey(key))
        {
            callbacks[key].AddFirst(cb);
            return true;
        }
        
        events.Add(key, false);
        var ll = new LinkedList<Callback>();
        ll.AddFirst(cb);
        callbacks.Add(key, ll);
        return false;
    }

    public void Satisfy(String key, bool destroyCallbacks = true)
    {
        Logger.Instance.Log("Objective Satisfied: "+key);
        if (!events.ContainsKey(key))
        {
            events.Add(key,true);
        }
        else if(callbacks.ContainsKey(key) && !events[key])
        {
            foreach (Callback cb in callbacks[key])
            {
                cb();
            }

            if (destroyCallbacks) callbacks[key] = null;
            events[key] = true;
        }
    }

    public bool Check(String key)
    {
        return events.ContainsKey(key) && events[key];
    }
}
