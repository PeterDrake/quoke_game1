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
    private GameObject myPlayer;
   // public GameObject myGameManager;

    

    public IEnumerator MyPause()
    {
        myPlayer = GameObject.FindWithTag("Player");
        yield return new WaitForSeconds(.1f);
        myPlayer.GetComponent<CharacterPause>().PauseCharacter();
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
        myPlayer.GetComponent<CharacterPause>().UnPauseCharacter();
        //myGameManager.GetComponent<GameManager>().UnPause();
        GameManager.Instance.UnPause();
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }
}
