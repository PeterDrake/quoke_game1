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
    public GameObject rearranger;
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
        Debug.Log(rearranger.GetComponent<Rearrange>().safe);

    }

    public void Fall()
    {
        if (string.Compare(sceneName, "Level 2")==0)
        {
            if (rearranger.GetComponent<Rearrange>().safe == false)
            {
                Debug.Log(rearranger.GetComponent<Rearrange>().safe);
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
//            Debug.Log("supposed to happen::Trigger");
            Debug.Log(rearranger.GetComponent<Rearrange>().safe);

            if ((isEnabled))
            {
                Debug.Log("Player Hit");
                death.text = "Your bookcase crushed you to death! :(";
                health.GetComponent<Slider>().value = health.GetComponent<Slider>().minValue;
//          DeathScreen.GetComponent<Death>().PlayerDeath();
            }
        }
        
        if (other.gameObject.CompareTag("NPC2"))
        {
            if (rearranger.GetComponent<Rearrange>().safe==false)
            {
                npc2.GetComponent<FollowPlayer>().fall = true;

            }
        }
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("NPC2"))
        {
            if (rearranger.GetComponent<Rearrange>().safe==false)
            {
                Debug.Log("supposed to happen");
                npc2.GetComponent<FollowPlayer>().fall = true;

            }
        }
    }
    
}
