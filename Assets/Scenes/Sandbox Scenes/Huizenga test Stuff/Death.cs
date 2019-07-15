using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MoreMountains.TopDownEngine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{ 
    public GameObject deathScreen;
    //public GameObject end;
    //public GameObject level;
    public GameObject myPlayer;
    public GameObject myGameManager;

    // Start is called before the first frame update
    void Start()
    {
       // myPlayer = GameObject.FindWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator MyPause()
    {
        myPlayer = GameObject.FindWithTag("Player");
        yield return new WaitForSeconds(.1f);
        myPlayer.GetComponent<CharacterPause>().PauseCharacter();
        myGameManager.GetComponent<GameManager>().Pause();
    }
    
    public void PlayerDeath()
    {
        deathScreen.SetActive(true);
        StartCoroutine(MyPause());
       // myPlayer.GetComponent<CharacterPause>().PauseCharacter();
        //myGameManager.GetComponent<GameManager>().Pause();
        

    }

    public void RestartLevel()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }
}
