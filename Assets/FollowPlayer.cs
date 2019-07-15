using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using UnityEngine.AI;
using MoreMountains.TopDownEngine;
using UnityEngine;


public class FollowPlayer : MonoBehaviour
{

    
    public GameObject me;
    public Character player;
    public NavMeshAgent npc;
    public int i = -500;

    private Vector4 pos; 
   // private float speed = 3.0f;
    void Start ()
    {
        //At the start of the game, the zombies will find the gameobject called wayPoint.
      //  wayPoint = GameObject.Find("wayPoint");
      Vector3 add = new Vector3(2, 0, 4);
      pos = me.transform.position + add;
    }
 
    void Update ()
    {
        
        //wayPointPos = new Vector3(wayPoint.transform.position.x, transform.position.y, wayPoint.transform.position.z);
        //Here, the zombie's will follow the waypoint.
        if (i>0)
        {       
            npc.SetDestination(player.transform.position);
            Debug.Log(npc.destination);
            
            // transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
        i++;
    }
}
