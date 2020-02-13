using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.FeedbacksForThirdParty;
using MoreMountains.InventoryEngine;
using MoreMountains.TopDownEngine;
using UnityEngine.SceneManagement;
 
public class SanitationBuilt : MonoBehaviour
{
    private const string MiniGameSceneName = "ToiletMiniGame";
    
    
    private InteractWithObject _interact;
    private InventoryHelper _inventory;
 
    private Item Bucket;
    private Item Bag;
    private Item Sawdust;
    private Item Sanitizer;
    private Item ToiletPaper;

    public GameObject Buckets;
 
    private bool HasSanitizer;
    private bool HasBuckets;
    private bool HasBag;
    private bool HasSawdust;

    private byte Conditions;
    
    
    private GameObject canvi;
    private GameObject camera;
    
     
    void Start()
    {
        _interact = GetComponent<InteractWithObject>();
        _inventory = GameObject.FindWithTag("MainInventory").GetComponent<InventoryHelper>();
         
        Bucket =  Resources.Load<Item>("Items/Bucket");
        Bag =  Resources.Load<Item>("Items/Bag");
        Sawdust =  Resources.Load<Item>("Items/Sawdust");
        Sanitizer =  Resources.Load<Item>("Items/Sanitizer");
        ToiletPaper =  Resources.Load<Item>("Items/ToiletPaper");
        _inventory.CheckOnAdd.AddListener(UpdateConditions);
    }
    
    public void Interaction()
    {
        if ((Conditions ^ 0xF) == 0)
        {
            SceneManager.LoadScene(MiniGameSceneName, LoadSceneMode.Additive);
            SceneManager.sceneLoaded += StartMinigame;
        }
        else
        {
            _interact.SetInteractText("You need to gather more items");
        }
    }
    //CAMERA, ui, move stage up a lot
    private void UpdateConditions() //called every time an item is added to the inventory 
    {
        if ((Conditions ^ 0xF) == 0) return;

        if ((Conditions & 0x1) > 0 || _inventory.HasItem(Bucket, 2)) //first condition not met
            Conditions |= 0x1;
        
        if ((Conditions & 0x2) > 0 || _inventory.HasItem(Bag, 1)) //second condition not met
            Conditions |= 0x2;
        
        if ((Conditions & 0x4) > 0 || _inventory.HasItem(Sawdust, 1)) //third condition not met
            Conditions |= 0x4;

        if ((Conditions & 0x8) > 0 || _inventory.HasItem(Sanitizer, 1)) //fourth condition not met
            Conditions |= 0x8;
    }

    private void StartMinigame(Scene scn, LoadSceneMode lsm)
    {
        StatusManager.Manager.Pause();
        SceneManager.sceneLoaded -= StartMinigame;
        
        (canvi = GameObject.Find("Canvi")).SetActive(false);
        (camera = GameObject.Find("Cameras")).SetActive(false);
        GameObject.Find("MinigameMaster").GetComponent<MiniGameMaster>().OnWin += MiniGameFinished;
        Buckets.SetActive(true);
        Destroy(gameObject);
    }
    private void MiniGameFinished()//this is not getting called
    {
        StatusManager.Manager.Unpause();

        SceneManager.UnloadSceneAsync(MiniGameSceneName);
        canvi.SetActive(true);
        
        ObjectiveManager.Instance.Satisfy("TOILETEVENT");
        camera.SetActive(true);
        canvi.SetActive(true);

        _inventory.RemoveItem(Bucket, 2);
        _inventory.RemoveItem(Bag, 1);
        _inventory.RemoveItem( Sawdust, 1);
        _inventory.RemoveItem( Sanitizer, 1);
        _inventory.RemoveItem( ToiletPaper, 1);

        Destroy(this);
    }
}
