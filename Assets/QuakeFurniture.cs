using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuakeFurniture : MonoBehaviour
{
    public GameObject[] falling_objects;
    public float fallRate = .5f;
    private int i = 0;
    public bool underTable = true;


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
    }
}
