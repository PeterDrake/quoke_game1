using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VanNextLevel : MonoBehaviour
{
    private InteractWithObject _interact;
    private void Start()
    {
        _interact = GetComponent<InteractWithObject>();
    }

    public void Interaction()
    {
        SceneManager.LoadScene("DemoMenu", LoadSceneMode.Single);
    }
}
