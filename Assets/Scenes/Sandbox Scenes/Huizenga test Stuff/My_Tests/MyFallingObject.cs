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
    public Slider health;
    public GameObject DeathScreen;
    public GameObject npc2;
    public Text death;
    public bool isEnabled = false;

    private Scene currentScene;

    private string sceneName;
    //public Vector3 push_point;
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        rb = GetComponent<Rigidbody>();
    }

    public void Fall()
    {
        if (string.Compare(sceneName, "Level 2")==0)
        {
            if (GetComponent<Pushable>().safe == false)
            {
                Debug.Log(GetComponent<Pushable>().safe);
                isEnabled = true;
                rb.AddRelativeForce(Vector3.forward * thrust);
                StartCoroutine(BookshelfDeactivate());
            }
        }
        else
        {
//            Debug.Log(GetComponent<Pushable>().safe);
            isEnabled = true;
            rb.AddRelativeForce(Vector3.forward * thrust);
            StartCoroutine(BookshelfDeactivate());
        }
        
    }

//    public void NPCDeath()
//    {
//        npc2.GetComponent<FollowPlayer>().fall = true;
//    }

    public IEnumerator BookshelfDeactivate()
    {
        yield return new WaitForSeconds(2f);
        isEnabled = false; 
        GetComponent<Rigidbody>().isKinematic = true;
    }


    //how do we ensure that the Earthquake is actually happening?
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
             if ((isEnabled))
             {
                 Debug.Log("Player Hit");
                 death.text = "Your bookcase crushed you to death! :(";
                 health.GetComponent<Slider>().value = health.GetComponent<Slider>().minValue;
//          DeathScreen.GetComponent<Death>().PlayerDeath();
             }
        }
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("NPC2"))
        {
            npc2.GetComponent<FollowPlayer>().fall = true;
        }
    }
}
