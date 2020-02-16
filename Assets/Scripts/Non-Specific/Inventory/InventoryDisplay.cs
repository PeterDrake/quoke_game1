using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InventoryDisplay : MonoBehaviour
{
    [SerializeField] private GameObject SlotPrefab;
    // itemPanel(gameObject to display item sprites), viewPanel (to show selected item's display image/description), exit button
    // use button?

    private byte requiredComponentsAmount = 10;
    private GameObject toggler;

    private Image displayImage;
    private Image[] itemSlots;
    private Text description;
    private Text displayName;
    private Text displayAmount;

    private GameObject useToggle;
    private Text useText;
    private Button useButton;

    private int selectedItem;

    private byte capacity;
    private Item[] inventory;
    private byte[] amounts;

    public void End()
    {
        toggler.SetActive(false);
    }

    public void Load(Item[] items, byte[] amounts)
    {
        if (items.Length == 0) return;
        
        activate(true);
        useToggle.SetActive(false);
        inventory = items;
        this.amounts = amounts;

        if (amounts[selectedItem] == 0) selectedItem = -1;
        
        int i = 0;
        bool first = false;
        // add in behavior if there is no items in the back pack (maybe just a message that disallows opening inv)
        
        foreach (Image item in itemSlots)
        {
            if (i >= items.Length) break;
            if (amounts[i] == 0)
            {
                item.enabled = false;
            }
            else
            {
                item.enabled = true;
                item.sprite = items[i].Icon;
                if (!first && selectedItem == -1)
                {
                    selectedItem = i;
                    first = true;
                }                
            }
            i += 1;
        }
        setActiveItem(selectedItem);
    }

    private void Start()
    {
        selectedItem = 0;
        capacity = InventoryHelper.Instance.GetCapacity();
        itemSlots = new Image[capacity];
        initialize();
        activate(false);
    }

    private void initialize() //Get all references that are needed to populate the dialogue UI
    {
        Transform main = transform.Find("InventoryToggler");
        toggler = main.gameObject;
        byte componentsFound = 1;
        
        foreach (Transform child in main)
        {
            switch (child.name)
            {
                case "itemPanel":
                    componentsFound += 1;
                    for (int i = 0; i < capacity; i++)
                    {
                        GameObject inst = Instantiate(SlotPrefab, child);
                        itemSlots[i] = inst.transform.Find("icon").GetComponent<Image>();
                        
                        int k = i;
                        inst.GetComponent<Button>().onClick.AddListener(delegate {setActiveItem(k);});
                    }
                    break;
                case "displayImage":
                    componentsFound += 1;
                    displayImage = child.GetComponent<Image>();
                    break;
                case "displayAmount":
                    componentsFound += 1;
                    displayAmount = child.GetComponent<Text>();
                    break;
                case "description":
                    componentsFound += 1;
                    description = child.GetComponent<Text>();
                    break;
                case "displayName":
                    componentsFound += 1;
                    displayName = child.GetComponent<Text>();
                    break;
                case "exitButton":
                    componentsFound += 1;
                    child.GetComponent<Button>().onClick.AddListener(Exit);
                    break;
                case "useToggler":
                    componentsFound += 3;
                    useToggle = child.gameObject;
                    Transform button = child.Find("use");
                    button.GetComponent<Button>().onClick.AddListener(useSelectedItem);
                    useText = button.Find("text").GetComponent<Text>();
                    break;
            }
        }
        if (componentsFound != requiredComponentsAmount) 
            throw new Exception("Required Components for Dialogue Displayer were not found!");
    }
    private void setActiveItem(int i)
    {
        if (inventory[i] == null) return;

        selectedItem = i;
        
        displayImage.sprite = inventory[i].DisplayImage;
        displayName.text = inventory[i].DisplayName;
        description.text = inventory[i].Description;
        displayAmount.text = amounts[i].ToString();

        if (inventory[i].action != null)
        {
            useToggle.SetActive(true);
            useText.text = inventory[i].action.ActionWord;
        }
    }
    
    public void Exit()
    {
        activate(false);   
    }
    
    private void activate(bool active)
    {
        toggler.SetActive(active);
    }

    private void useSelectedItem()
    {
        InventoryHelper.Instance.UseItem(selectedItem);
    }
}
