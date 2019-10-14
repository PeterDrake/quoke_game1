using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MyFallingObject : MonoBehaviour
{
    public float thrust;
    public Rigidbody rb;

    
    public GameObject rearranger;
    public Rearrange _rearranger;
    
    public GameObject npc2;
    public bool isEnabled = false;
    
    public bool isSceneTwo;
    
    void Start()
    {
        var sceneName = SceneManager.GetActiveScene().name;
        isSceneTwo = string.Compare(sceneName, "Level 2") == 0;
        rb = GetComponent<Rigidbody>();
        _rearranger = rearranger.GetComponent<Rearrange>();

    }

    public void Fall()
    {
        if (isSceneTwo)
        {
            if (_rearranger.safe == false)
            {
                isEnabled = true;
                rb.AddRelativeForce(Vector3.forward * thrust);
                StartCoroutine(BookshelfDeactivate());
            }
        }
        else
        {
            isEnabled = true;
            rb.AddRelativeForce(Vector3.forward * thrust);
            StartCoroutine(BookshelfDeactivate());
        }
        
    }
    
    
    public IEnumerator BookshelfDeactivate()
    {
        yield return new WaitForSeconds(2f);
        isEnabled = false; 
        rb.isKinematic = true;
        
        if (isSceneTwo)
        {
            npc2.GetComponent<FollowPlayer>().fall = true;
        }

    }


    //how do we ensure that the Earthquake is actually happening?
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if ((isEnabled))
            {
                Debug.Log("Player Hit");
                Death.Manager.PlayerDeath("Your bookcase crushed you to death! :(");
            }
        }
    }
    
    
}
