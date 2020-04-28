using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MiniGameMaster : MonoBehaviour
{

    public bool Bucket;

    public bool PlasticBag;

    public bool Poop;

    public bool ToiletPaper;

    public bool Sawdust;

    public bool Pee;
    
    public GameObject Win;

    public GameObject Wrong;
    
    public UnityAction OnWin;

    public UnityAction OnExit;

    public void Start()
    {
        //OnWin= new UnityAction();
    }

    public void CheckCorrect()
    {
        if (Bucket && PlasticBag && Poop && ToiletPaper && Sawdust && Pee)
        {
            OnWin.Invoke();
            Win.SetActive(true);
        }
        else
        {
            StartCoroutine(TryAgain());
        }
    }

    public void Leave()
    {
        OnExit.Invoke();
    }

    public IEnumerator TryAgain()
    {
        Wrong.SetActive(true);
        yield return new WaitForSeconds(3f);
        Wrong.SetActive(false);
    }
    

    
    
}
