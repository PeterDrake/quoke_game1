using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using UnityEngine.AI;
using MoreMountains.TopDownEngine;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;


public class FollowPlayer : MonoBehaviour
{

    
    private GameObject me;
    public GameObject npc;
    private GameObject player;
   // public NavMeshAgent npc;
    public int i = -500;
    public Rigidbody rigidbody;
    private Vector3 pos;
    private Vector3 diff;
    private Vector3 near;


    public float speed;
   // private float speed = 3.0f;
    void Start ()
    {
        rigidbody.constraints = RigidbodyConstraints.FreezePositionY;
        player = GameObject.FindWithTag("Player");
        //me = GameObject.FindWithTag("NPC2");
        diff = transform.position - player.transform.position;
        diff.y = 1;
        //At the start of the game, the zombies will find the gameobject called wayPoint.

    }
 
    void LateUpdate ()
    {
//            float interpolation = speed * Time.deltaTime;
//            Vector3 position = me.transform.position;
//            Debug.Log(position);
//            position.z = Mathf.Lerp(me.transform.position.z, player.transform.position.z, interpolation);
//            position.x = Mathf.Lerp(me.transform.position.x, player.transform.position.x, interpolation);
//            Debug.Log(position);
//            GameObject.FindWithTag("NPC2").transform.position = position;
//            transform.Translate(position); 
//            Debug.Log("player position:"+player.transform.position)
        
            Debug.Log(transform.position);
            
            rigidbody.constraints = RigidbodyConstraints.FreezePositionY;
            pos = transform.position;
            pos.y = 1;
            near = player.transform.position - new Vector3(1, 0, 1);
            transform.position = Vector3.MoveTowards(pos, near, speed * Time.deltaTime);
           //transform.position = player.transform.position + diff;
           rigidbody.constraints = RigidbodyConstraints.FreezePositionY;
           
            Debug.Log(transform.position);
        
    }
}
