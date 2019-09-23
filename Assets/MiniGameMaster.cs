using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckCorrect()
    {
        if (Bucket && PlasticBag && Poop && ToiletPaper && Sawdust && Pee)
        {
            Win.SetActive(true);
        }
        else
        {
            StartCoroutine(TryAgain());
        }
    }

    public IEnumerator TryAgain()
    {
        Wrong.SetActive(true);
        yield return new WaitForSeconds(3f);
        Wrong.SetActive(false);

        
    }

    
    
}
