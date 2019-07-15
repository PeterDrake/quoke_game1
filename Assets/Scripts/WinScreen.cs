using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MoreMountains.TopDownEngine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    public GameObject winScreen;
    public GameObject myPlayer;
    public GameObject myGameManager;

    //public GameObject end;

    public GameObject Level;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MyPause());
  
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
        winScreen.SetActive(true);
        StartCoroutine(MyPause());

    }

    public void NextLevel()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("Level2");
    }
}
