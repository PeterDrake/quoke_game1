using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class SecureBookshelf : MonoBehaviour
{
    public GameObject eventTracker;
    public GameObject protector;
    public GameObject straps;
    public GameObject mainInventory;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SecureShelf()
    {
           // Debug.Log("Secured");
            straps.SetActive(true);
            GetComponent<MyFallingObject>().thrust = 0;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            protector.SetActive(true);
   
    }
}
