using UnityEngine;
using System.Collections;
using MoreMountains.Tools;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine.UI;
using MoreMountains.InventoryEngine;

namespace MoreMountains.InventoryEngine
{
    public class myInventoryManager : MonoBehaviour
    {

        public int selectionNumber;

        public GameObject my_selectorDisplay;
        public InventorySlot my_inventorySlot;
        private Inventory my_inventory;

		

        private Inventory[] my_invent_list;
        private int my_index;
        private InventoryItem my_item;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

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
            }
        }
    }
}
