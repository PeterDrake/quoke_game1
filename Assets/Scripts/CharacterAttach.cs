using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using MoreMountains.TopDownEngine;
using UnityEngine.EventSystems;
using UnityEngine;
//using MoreMountains.Tools;
//using MoreMountains.Feedbacks;
//using MoreMountains.FeedbacksForThirdParty;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class CharacterAttach : MonoBehaviour
{

    public Character[] players;
    public GameObject levelManager;
    private bool selected = false;
    private Character _character;
    private string buttonName;
    private int numPlayers;
    
// Start is called before the first frame update
    void Start()
    {
        numPlayers = players.Length;

    }

    
    // Update is called once per frame
    void Update()
    {
        
    }
    /*Assign a character to a name */
    public void Assign()
    {
        
        buttonName= EventSystem.current.currentSelectedGameObject.name;
        for (int i = 0; i < numPlayers ; i++)
        {
            if (players[i].transform.name == buttonName)
            {
                _character = players[i];
            
            }
        }
        

        Debug.Log(_character);
    }
    
    /*
     * Selecting the character and passing it to the level manager
     */
    public void Selection()
    {

        levelManager.GetComponent<LevelManager>().PlayerPrefabs[0] = _character;
        Debug.Log(levelManager.GetComponent<LevelManager>().PlayerPrefabs[0]);
        selected = true;
    }
    
  

     
}
