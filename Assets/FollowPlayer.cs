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
    private Vector3 pos;
    private Vector3 diff;
    private Vector3 far;
    private Vector3 near;
    private bool follow = false;
    public float speed;
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

    }
    
    /**
     * NPC follows the player by moving towards them and stopping 1 unit x and z near them.
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            Debug.Log(other.gameObject.name);
            Debug.Log("in the house");
            follow = false;
            far = bookshelf.transform.position - new Vector3(7, 0, 1);
            near = bookshelf.transform.position - new Vector3(1, 0, 0);
            Go();
        }
    }

    void Go()
    {
        transform.position = Vector3.MoveTowards(transform.position,far, speed*Time.deltaTime);
        Debug.Log(far);
        Debug.Log(near);
        Debug.Log(transform.position);
        Debug.Log("far");
        
        if (Vector3.Distance(transform.position,far)<.01f)
        {
            Debug.Log("near");
            transform.position = Vector3.MoveTowards(transform.position,near,speed*Time.deltaTime);
        }

    }
}
