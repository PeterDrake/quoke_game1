using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuakeFurniture : MonoBehaviour
{
    public GameObject[] falling_objects;
    public float fallRate = .5f;
    private int i = 0;
    public bool underTable = true;
    public GameObject myPlayer;
    private Vector3 playerTransform;
    public GameObject playerKiller;


    private void Start()
    {
        myPlayer = GameObject.FindWithTag("Player");
    }

    public void Drop()
    {
        StartCoroutine(DropEm());
    }
    

    public IEnumerator DropEm()
    {
        yield return new WaitForSeconds(3f);
        while (i < falling_objects.Length && underTable)
        {
            falling_objects[i].SetActive(true);
            yield return new WaitForSeconds(fallRate);
            i++;
            if (fallRate>.2f)
            {
                fallRate -= .005f;
            }
        }
        ////drop directly on players head

        playerTransform = myPlayer.transform.position;
        playerKiller.transform.position = playerTransform +  new Vector3(0f,3f,0f);
        playerKiller.SetActive(true);
        

    }
}
