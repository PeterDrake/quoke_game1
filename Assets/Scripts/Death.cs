using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MoreMountains.TopDownEngine;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using MoreMountains.TopDownEngine;

public class Death : MonoBehaviour
{ 
    public GameObject deathScreen;
    public Text deathText;
    private CharacterPause pause; 

    public static Death Manager;
    private bool dead;
   
   public void Start()
   {
       pause = GameObject.FindWithTag("Player").GetComponent<CharacterPause>();
       if (Manager == null) Manager = this;
       else Destroy(this);
   }


   private IEnumerator MyPause()
    {
        yield return new WaitForSeconds(.1f);
        pause.PauseCharacter();
        GameManager.Instance.Pause();
    }
    
    public void PlayerDeath(string textOnDeath)
    {
        if (dead) return;
        Logger.Instance.Log("Player killed by: "+textOnDeath);
        dead = true;
        deathText.text = textOnDeath;
        deathScreen.SetActive(true);
    }

    public void RestartLevel()
    {
        /* Removing Pause buggy stuff for now, will revisit*/
      //  pause.UnPauseCharacter();
        //myGameManager.GetComponent<GameManager>().UnPause();
       // GameManager.Instance.UnPause();
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }
}
