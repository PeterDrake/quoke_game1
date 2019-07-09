using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuakeFurniture : MonoBehaviour
{
    public GameObject[] falling_objects;

    private int i = 0;


    public void Drop()
    {
        StartCoroutine(DropEm());
    }

    public IEnumerator DropEm()
    {
        while (i < falling_objects.Length)
        {
            falling_objects[i].SetActive(true);
            yield return new WaitForSeconds(.5f);
            i++;
        }
    }
}
