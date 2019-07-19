using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using UnityEngine.AI;
using MoreMountains.TopDownEngine;
using TreeEditor;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using UnityEngine.UI;


public class FollowPlayer : MonoBehaviour
{

    
    private GameObject me;
    public GameObject npc;
    public GameObject player;
    public Dialogue housing;
    public GameObject bookshelf;
   // public NavMeshAgent npc;
    public int i = -500;
    public Rigidbody rigidbody;
    public float speed;
    public Slider playerHealth;
    public Text deathText;
    public bool follow = false;
    public bool fall = false;
    public bool goBookshelf = false;

    
    private Vector3 pos;
    private Quaternion rot;
    private Vector3 diff;
    private Vector3 far;
    private Vector3 near;
   // private float speed = 3.0f;
   
   /**
    * Assign the player and the constraints for the NPC
    */
    void Start ()
    {
        rigidbody.constraints = RigidbodyConstraints.FreezePositionY;
        player = GameObject.FindWithTag("Player");
        //me = GameObject.FindWithTag("NPC2");
        diff = transform.position - player.transform.position;
        diff.y = 1;
        transform.rotation= Quaternion.Euler(0,0,0);

    }
    
    /**
     * 
     * NPC follows the player by moving towards them and stopping 1 unit x and z near them --> the follow if statement
     * When they are inside, NPC goes in front of the bookcase and stands there --> the goBookshelf if statement
     * if the bookcase falls, NPC dies and player loses the game --> the fall if statement
     *
     */
    void Update ()
    {

      //  Debug.Log(transform.position);
//            rigidbody.constraints = RigidbodyConstraints.FreezePositionY;
        if (follow)
        {
            if (Vector3.Distance(player.transform.position,transform.position) < 2f)
            {
                transform.position = transform.position;
            }
            else
            {
                //diff = transform.position - player.transform.position;
                rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                pos = transform.position;
                pos.y = 1;
                diff.y = 1;
               // near = player.transform.position + new Vector3(1, 0, 1);
                //transform.position = near;
                transform.position = Vector3.MoveTowards(pos, player.transform.position, speed * Time.deltaTime);
            }

        }
        

        if (goBookshelf)
        {
            if (Vector3.Distance(transform.position,bookshelf.transform.position)< 2f)
            {
                transform.position = transform.position;
                rigidbody.isKinematic = false;
            }

            else
            {
                follow = false;
                far = bookshelf.transform.position - new Vector3(7, 0, 1);
                near = bookshelf.transform.position - new Vector3(1, 0, 0);
                pos = Vector3.MoveTowards(transform.position, bookshelf.transform.position, 1f * Time.deltaTime);
                pos.y = 1;
                transform.position = pos;
//            Go();
//            Debug.Log("far"+far);
//            Debug.Log("near"+near);
//            Debug.Log("bookshelf"+bookshelf.transform.position);
//            Debug.Log(transform.position);
//            Debug.Log("far");
//        if (Vector3.Distance(transform.position,far)<.01f)
//        {
                //Debug.Log("near");
//            pos = 
//            pos.y = 1;
                // transform.position = Vector3.MoveTowards(transform.position, near, 1f * Time.deltaTime);
                //rigidbody.isKinematic = false;
                //}
            }
        }

        if (fall)
        {
            if (transform.rotation.x <= 0)
            {
                Debug.Log("fallen");
                transform.rotation= Quaternion.Euler(90,0,0);
                pos = transform.position;
                pos.y = pos.y - 1;
                transform.position = pos;
                deathText.text= "Your friend died, Game Over!";
                playerHealth.GetComponent<Slider>().value = playerHealth.GetComponent<Slider>().minValue;
                fall = false;
                
            }

        }
//        Debug.Log("npc: "+transform.position);
//        Debug.Log("Player: "+player.transform.position);

    }
    
    /**
     * After the player starts conversing with the NPC, enable the follow system
     */

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown("e"))
            {
                follow = true;
            }
        }
        
    }

//    private void OnTriggerEnter(Collider other)
//    {
//        if (other.CompareTag("Bookshelf"))
//        {
//            fall = true;
//        }
//    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Door"))
        {
            goBookshelf = true;

        }
    }
    
}
