using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MoreMountains.TopDownEngine;
using UnityEngine;
using UnityEngine.UIElements;

public class ChooseCharacter : MonoBehaviour
{

    public GameObject levelManager;

    Character _player;

    private Character myplsfst;
   // public Button[] options;
  public GameObject options;
    // Start is called before the first frame update
    void Start()
    {
      //  _player = options.GetComponent<CharacterAttach>().Selection();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    /*Choose Character*/
    
    public void Choose()
    {
//        levelManager.GetComponent<LevelManager>().PlayerPrefabs = 
        Debug.Log(_player.transform.name);
       levelManager.GetComponent<LevelManager>().PlayerPrefabs[0] = _player;

    }
    
}
