using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.FeedbacksForThirdParty;
using UnityEngine;

public class QuakeFurniture : MonoBehaviour
{
    /// <summary>
    /// Drops and staggers the falling furniture, the longer the quake goes, the faster stuff falls, at the very end
    /// we drop an object directly on the players head if they still haven't gotten under the table or died
    /// </summary>
    
    public GameObject[] falling_objects;
    public float fallRate = .5f;
    public GameObject player;
    public GameObject playerKiller;
    
    private bool dropping;
    private Vector3 playerTransform;
    private int i = 0;


    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        QuakeManager.Instance.OnQuake.AddListener(Drop);
    }

    private void Drop()
    {
        StartCoroutine(DropEm());
    }
    
    private IEnumerator DropEm()
    {
        dropping = true;
        yield return new WaitForSeconds(3f);
        while (QuakeManager.Instance.Quaking &&  i < falling_objects.Length)
        {
            falling_objects[i].SetActive(true);
            yield return new WaitForSeconds(fallRate);
            i++;
            if (fallRate>.2f)
            {
                fallRate -= .005f;
            }
        }
        // drop directly on players head
        if (i == falling_objects.Length)
        {
            playerTransform = player.transform.position;
            playerKiller.transform.position = playerTransform + new Vector3(0f, 3f, 0f);
            playerKiller.SetActive(true);
        }
    }
}
