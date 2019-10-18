using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.InventoryEngine;

public class PickupHose : MonoBehaviour
{
    public BaseItem itemtoReceive;
    public GameObject interactNotifier;

    private Inventory inv;
    private bool isColliding;
    public bool killAfterUse = true;

    public void Start()
    {
        inv = GameObject.FindWithTag("MainInventory").GetComponent<Inventory>();
    }

    private void OnTriggerStay(Collider other) 
    {
        if (other.CompareTag("Player"))
        {
            
            if (Input.GetAxis("Interact") != 0)
            {
                if (isColliding) return;
                isColliding = true;

                if (itemtoReceive != null)
                {
                    inv.AddItem(itemtoReceive,1);
                }

                interactNotifier.SetActive(false);
                if (killAfterUse) Destroy(this);
            }
            

        }
    }
}
