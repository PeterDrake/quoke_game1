using UnityEngine;
using System.Collections;
using MoreMountains.Tools;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine.UI;
using MoreMountains.InventoryEngine;

namespace MoreMountains.InventoryEngine
{
    public class myInventoryManager : MonoBehaviour
    {

        public int selectionNumber;

        public GameObject my_selectorDisplay;
        public InventorySlot my_inventorySlot;
        public GameObject eventTracker;
        public GameObject bookcase;
        private Inventory my_inventory;

        private Inventory[] my_invent_list;
        private int my_index;
        private InventoryItem my_item;
        

        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(my_OpenInvent());
        }

        // Update is called once per frame
        void Update()
        {

        }

        IEnumerator my_OpenInvent()
        {
            yield return new WaitForEndOfFrame();
            GetComponent<InventoryInputManager>().OpenInventory();

        }
        public void ChangeInventory()

        {
            my_inventorySlot = GetComponent<InventoryInputManager>().CurrentlySelectedInventorySlot;
            my_index = my_inventorySlot.Index;
            my_item = my_inventorySlot.ParentInventoryDisplay.TargetInventory.Content[my_index];
            //Debug.Log(my_item);
            my_invent_list = FindObjectsOfType<Inventory>();
            my_inventory = my_invent_list[1];
            //Debug.Log(my_inventory);
            my_inventory.AddItem(my_item,1);
            my_inventorySlot.DisableSlot();
            //make a counter for the number of items selected... select 2 out of 4, etc. 
			
        }


        public void MySelectItem()
        {
            ChangeInventory();

            selectionNumber--;
            if (selectionNumber <= 0)
            {
                
                GetComponent<InventoryInputManager>().CloseInventory();
                my_selectorDisplay.SetActive(false);
                if (eventTracker.GetComponent<MyEventTracker>().my_CheckInventory("SecureBookcase"))
                {
                    bookcase.GetComponent<SecureBookshelf>().SecureShelf();
                }
            }
        }
        
    }
}
