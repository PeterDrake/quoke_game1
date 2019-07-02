using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using MoreMountains.TopDownEngine;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UIElements;

public class CharacterAttach : MonoBehaviour
{
    Character _character;
    
//    public GameObject hotDog;
//    public GameObject suspenders;
    public Character[] players;
    public GameObject levelManager;
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
//Assign a character to a name
    public void Assign()
    {
//        Debug.Log(EventSystem.current.currentSelectedGameObject.name);
//        Debug.Log(numPlayers);
        buttonName= EventSystem.current.currentSelectedGameObject.name;
//        Debug.Log(buttonName+"+");
//        Debug.Log(players.ElementAt(1).transform.name+"+");
        for (int i = 0; i < numPlayers ; i++)
        {
            if (players[i].transform.name == buttonName)
            {
                _character = players.ElementAt(i);
//                Debug.Log(players[i].transform.name);
//                Debug.Log(players[i].GetType());
//                Debug.Log(players[i]);
//                Debug.Log("same");
            }
        }
        
//        Debug.Log(_character.transform.name);
//        Debug.Log(_character.GetType());
       Debug.Log(_character);
        //selectB.SetActive(true);
    }
    
//Selecting the character    
    public void Selection()
    {
        levelManager.GetComponent<LevelManager>().PlayerPrefabs[0] = _character;
        Debug.Log(levelManager.GetComponent<LevelManager>().PlayerPrefabs[0]);


    }
     
}
