using System;
using UnityEngine;
using System.Collections;
using MoreMountains.Tools;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Boo.Lang.Environments;
using UnityEngine.UI;
using MoreMountains.InventoryEngine;

namespace MoreMountains.InventoryEngine
{
    public class myInventoryManager : MonoBehaviour
    {

        public int selectionNumber;
        public InventorySlot my_inventorySlot;
        public GameObject my_selectorDisplay;
        public GameObject eventTracker;
        public GameObject bookcase;
        public GameObject infoEnabler;
        public GameObject inventoryDisplay;
        public Text name;
        
        private List<GameObject> slots;
        private Inventory mainInventory;
        private Inventory my_inventory;
        private Inventory[] my_invent_list;
        private InventorySlot bucketSlot;
        private InventorySlot inventorySlot;
        private InventoryItem my_item;
        private InventoryItem bucketItem;
        
        private int my_index;
        private int bucketIndex;

        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(my_OpenInvent());
            slots = inventoryDisplay.GetComponent<InventoryDisplay>().SlotContainer;
        }

        // Update is called once per frame
        void Update()
        {
            if (GetComponent<InventoryInputManager>().CurrentlySelectedInventorySlot != null)
            {
            bucketSlot = GetComponent<InventoryInputManager>().CurrentlySelectedInventorySlot;
            bucketIndex = bucketSlot.Index;
            bucketItem = bucketSlot.ParentInventoryDisplay.TargetInventory.Content[bucketIndex];
            name.GetComponent<Text>().text = bucketItem.name;
            }
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
            
            //Debug.Log(my_item.name);
            
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
               
                ///opens first instruction
                infoEnabler.SetActive(true);
                
                

                if (eventTracker.GetComponent<MyEventTracker>().my_CheckInventory("Bucket"))
                {
                   // bucketIndex = eventTracker.GetComponent<MyEventTracker>().my_InventorySlotIndex("Bucket");
                    //bucketSlot = eventTracker.GetComponent<MyEventTracker>().my_InventorySlot();
                }
            }
        }

        public void Name()
        {
            Debug.Log("name");
        }
        
    }
}
