using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using UnityEngine.AI;
using MoreMountains.TopDownEngine;
using UnityEngine;


public class FollowPlayer : MonoBehaviour
{

    
    private GameObject me;
    public GameObject npc;
    private GameObject player;
   // public NavMeshAgent npc;
    public int i = -500;

    private Vector3 pos;

    private Vector3 diff;
    
    
    public float speed = .0001f;
   // private float speed = 3.0f;
    void Start ()
    {
        player = GameObject.FindWithTag("Player");
        me = GameObject.FindWithTag("NPC2");
        //At the start of the game, the zombies will find the gameobject called wayPoint.
      //  wayPoint = GameObject.Find("wayPoint");
//      Vector3 add = new Vector3(2, 0, 4);
//      var position = this.transform.position;
//      pos = position + (player.transform.position - position); 
    }
 
    void Update ()
    {
        //        //wayPointPos = new Vector3(wayPoint.transform.position.x, transform.position.y, wayPoint.transform.position.z);
//        //Here, the zombie's will follow the waypoint.
//        
//        
//        if (i>0)
//        {       
//            npc.SetDestination(pos);
//            Debug.Log(npc.destination);
//            var position = this.transform.position;
//            diff = player.transform.position - position;
//            pos = position + diff;
//
//        }
//        
//        i

        if (i>0)
        { 
            float interpolation = speed * Time.deltaTime;
          //  Debug.Log(interpolation);
            Vector3 position = me.transform.position;
            position.z = Mathf.Lerp(me.transform.position.z, player.transform.position.z, interpolation);
            position.x = Mathf.Lerp(me.transform.position.x, player.transform.position.x, interpolation);
            GameObject.FindWithTag("NPC2").transform.position = position;
            transform.position = position;
            Debug.Log("player position:"+player.transform.position);
        }
        i++;

    }
}
