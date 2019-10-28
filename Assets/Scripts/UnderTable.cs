﻿using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using MoreMountains.FeedbacksForThirdParty;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UnderTable : MonoBehaviour
{
    public GameObject fallingObjects;
    public GameObject aftershocktrigger;
    public GameObject quakeTrigger;
    public GameObject tableCheck;
    private Scene currentScene;
    private string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;

    }
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            QuakeManager.Instance.tableFlag = false;

            if (string.Compare(sceneName, "Level 2")==0)
            {
                aftershocktrigger.GetComponent<AftershockTrigger>().tableFlag = false;
                tableCheck.SetActive(false);
            }
            
            fallingObjects.GetComponent<QuakeFurniture>().underTable = false;
        }
    } 
}
