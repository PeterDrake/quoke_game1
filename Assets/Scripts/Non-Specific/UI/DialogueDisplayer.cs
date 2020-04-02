
using System;
using UnityEngine;
using UnityEngine.UI;

public class DialogueDisplayer : UIElement
{
    public delegate string DialogueEvent();
    private const byte requiredComponentsAmount = 8;
    // option1, option2, invalid1, invalid2, npcImage, npcSpeech, npcName, exit 
    
    private DialogueNode activeDialogue;
    
    private DialogueEvent option1;
    private DialogueEvent option2;
    private DialogueEvent exit;
    private bool displaying;
    private GameObject toggler;
    
    // Object references for population of information
    private Image npcImage;
    private Text npcSpeech;
    private Text npcName;
    
    private Text optionOne;
    private Text optionTwo;
    [SerializeField] private GameObject responseOneEnabler;
    [SerializeField] private GameObject responseTwoEnabler;
    
    private Text invalidOne;
    private Text invalidTwo;
    private GameObject invalidOneEnabler;
    private GameObject invalidTwoEnabler;


    private void Awake()
    {
        pauseOnOpen = true;
    }

    public override void Close()
    {
        activate(false);
    }

    public override void Open()
    {
        activate(true);
    }
    
    public void Load(DialogueNode d, NPC n)
    {
        Debug.Log("Loading "+d.name+", "+n.name);
        npcName.text = n.name;
        if (n.image != null) npcImage.sprite = n.image;
        npcSpeech.text = d.speech;

        if (d.GetNodeOne() == null)
        {
            responseOneEnabler.SetActive(false);
        }
        else
        {
            responseOneEnabler.SetActive(true);
            optionOne.text = d.GetTextOne();
        }
        
        if (d.GetNodeTwo() == null)
        {
            responseTwoEnabler.SetActive(false);
            optionTwo.text = d.GetTextTwo();
        }
        else
        {
            responseTwoEnabler.SetActive(true);
            optionTwo.text = d.GetTextTwo();
        }
        
       UIManager.Instance.SetAsActive(this);
        /* Extra:
            check each options requirements, and enable invalids accordingly
        */
    }

    public void LinkEvents(DialogueEvent option1, DialogueEvent option2, DialogueEvent exit)
    {
        this.option1 = option1;
        this.option2 = option2;
        this.exit = exit;
    }

    public Tuple<bool, bool> ActiveOptions()
    {
        if (!displaying) return new Tuple<bool, bool>(false, false);
        return new Tuple<bool, bool>(activeDialogue.GetTextOne() != null, activeDialogue.GetTextTwo() != null);
    }

    private void Start()
    {
        locked = true;
        initialize();
        activate(false);   
    }
        
    private void initialize() //Get all references that are needed to populate the dialogue UI
    {
        byte componentsFound = 0;
        Transform main = transform.Find("DialogueToggler");
        toggler = main.gameObject;
        
        foreach (Transform child in main)
        {
            switch (child.name)
            {
                case "invalid1":
                    invalidOneEnabler = child.gameObject;
                    invalidOne = child.Find("text").GetComponent<Text>();
                    componentsFound += 1;
                    break;
                case "invalid2":
                    invalidTwoEnabler = child.gameObject;
                    invalidTwo = child.Find("text").GetComponent<Text>();
                    componentsFound += 1;
                    break;
                case "name":
                    npcName = child.GetComponent<Text>();
                    componentsFound += 1;
                    break;
                case "speech":
                    npcSpeech = child.GetComponent<Text>();
                    componentsFound += 1;
                    break;
                case "image":
                    npcImage = child.GetComponent<Image>();
                    componentsFound += 1;
                    break;
                case "option1":
                    child.GetComponent<Button>().onClick.AddListener(optionOnePressed);
                    optionOne = child.Find("text").GetComponent<Text>();
                    responseOneEnabler = child.gameObject;
                    componentsFound += 1;
                    break;
                case "option2":
                    child.GetComponent<Button>().onClick.AddListener(optionTwoPressed);
                    optionTwo = child.Find("text").GetComponent<Text>();
                    responseTwoEnabler = child.gameObject;
                    componentsFound += 1;
                    break;
                case "exit":
                    child.GetComponent<Button>().onClick.AddListener(exitPressed);
                    componentsFound += 1;
                    break;
            }
        }
        if (componentsFound != requiredComponentsAmount) 
            throw new Exception("Required Components for Dialogue Displayer were not found!");
    }

    // Called when the first dialogue option is pressed
    private void optionOnePressed()
    {
        string resp = option1();
        
        if (resp != "")
        {
            invalidOneEnabler.SetActive(true);
            invalidOne.text = resp;
        }
    }
    
    // Called when the second dialogue option is pressed
    private void optionTwoPressed()
    {
        string resp = option2();
        
        if (resp != "")
        {
            invalidTwoEnabler.SetActive(true);
            invalidTwo.text = resp;
        }
    }

    private void exitPressed()
    {
       UIManager.Instance.ActivatePrevious();
        exit();
    }

    private void activate(bool active)
    {
        toggler.SetActive(active);
    }
}
