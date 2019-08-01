using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MoreMountains.TopDownEngine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    public GameObject winScreen;
    private GameObject myPlayer;
    //public GameObject myGameManager;
    
    //public GameObject end;
    public GameObject objective;
    public GameObject Level;
    public GameObject aftershockTrigger;
    public bool sanitation;
    public bool shelter;
    public bool water;
    public bool aftershock;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MyPause());
        myPlayer = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
//        sanitation = objective.GetComponent<UpdateQuests>().sanitationBool;
//        shelter = objective.GetComponent<UpdateQuests>().shelterBool;
//        water = objective.GetComponent<UpdateQuests>().waterBool;
//        aftershock = aftershockTrigger.GetComponent<AftershockTrigger>().happened;
//
//        if (sanitation && shelter && water && aftershock)
//        {
//            Won();
//        }

    }

   
    
    public IEnumerator MyPause()
    {
        myPlayer = GameObject.FindWithTag("Player");
        yield return new WaitForSeconds(.1f);
        myPlayer.GetComponent<CharacterPause>().PauseCharacter();
        GameManager.Instance.Pause();
    }
    
    
    public void Won()
    {
        winScreen.SetActive(true);
        StartCoroutine(MyPause());

    }

    public void NextLevel()
    {
        
       // string currentSceneName = SceneManager.GetActiveScene().name;
       myPlayer.GetComponent<CharacterPause>().UnPauseCharacter();
       GameManager.Instance.UnPause();
        int sceneNumber = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneNumber + 1);

       
    }
}
