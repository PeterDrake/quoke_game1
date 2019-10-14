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
    
   
   public void Start()
   {
       pause = GameObject.FindWithTag("Player").GetComponent<CharacterPause>();
       if (Manager == null) Manager = this;
       else Destroy(this);
   }


   public IEnumerator MyPause()
    {
        yield return new WaitForSeconds(.1f);
        pause.PauseCharacter();
        //myGameManager.GetComponent<GameManager>().Pause();
        GameManager.Instance.Pause();
        
    }
    
    public void PlayerDeath(string textOnDeath)
    {
        deathText.text = textOnDeath;
        deathScreen.SetActive(true);
        StartCoroutine(MyPause());
    }

    public void RestartLevel()
    {
        pause.UnPauseCharacter();
        //myGameManager.GetComponent<GameManager>().UnPause();
        GameManager.Instance.UnPause();
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }
}
