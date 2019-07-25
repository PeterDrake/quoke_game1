using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using MoreMountains.InventoryEngine;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class SecureBookshelf : MonoBehaviour
{
    public GameObject eventTracker;
    public GameObject protector;
    public GameObject straps;
    public GameObject mainInventory;

    public GameObject inventoryCanvas;
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

            for (int i = 0; i < mainInventory.GetComponent<Inventory>().NumberOfFilledSlots; i++)
            {
                if (string.Compare(mainInventory.GetComponent<Inventory>().Content[i].name,"SecureBookcase")==0 )
                {
                    inventoryCanvas.GetComponent<UseItems>().Re_Move(i);
                }
            }
   
    }
}
