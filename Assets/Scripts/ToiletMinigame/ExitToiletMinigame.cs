using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitToiletMinigame : MonoBehaviour
{
    private void Start()
    {
    }

    
    public void LoadLevel()
    {
        SceneManager.LoadScene("GabeUseThisL2", LoadSceneMode.Single);
    }
}
