using MoreMountains.FeedbacksForThirdParty;
using MoreMountains.InventoryEngine;
using UnityEngine;

public class Bookcase : Pauseable
{
    [Header("Will check for this item to repair bookshelf")]
    public Item CheckItem;
    
    private const string NO_TOOLS = "This bookcase could fall over in an earthquake. I should secure it to the wall.";
    private  const string HAS_TOOLS = "Press 'E' to Secure the Bookshelf";
    
    [Header("The bookcase will fall on the player the (kill_count)th time the player enters the collider")]
    public int KillCount = 4;
    private float fallThrust = 900000;

    private int count = 0;
    
    private InteractWithObject _interact;
    private InventoryHelper _inventory;

    private bool PlayerHasItem = false;
    
    private Rigidbody rb;
    private bool isFalling = false;
    private BoxCollider fallCollider;


    private Vector3 vel;
    private Vector3 ang;

    [Header("Time it takes to trigger the earthquake after the bookcase is secured")]
    public float TriggerTime = 5f;
    
    private new void Start()
    {
        base.Start();
        _interact = GetComponent<InteractWithObject>();
        _inventory = GameObject.FindWithTag("MainInventory").GetComponent<InventoryHelper>();
        if (CheckItem == null) Debug.LogError("No item to check has been specified");
        rb = GetComponent<Rigidbody>();
        
        fallCollider = transform.Find("Fall Collider").GetComponent<BoxCollider>(); 
        fallCollider.gameObject.GetComponent<CollisionCallback>().AddCallback("Player", HitPlayer);
        fallCollider.enabled = false;

        //QuakeManager.Instance.OnQuake.AddListener(Fall);
    }

    public override void Pause()
    {
        vel = rb.velocity;
        ang = rb.angularVelocity;
        rb.isKinematic = true;
    }

    public override void UnPause()
    {
        rb.isKinematic = false;
        rb.velocity = vel;
        rb.angularVelocity = ang;
    }

    public void UpdateState()
    {
        if (isFalling) return;
        
        if (count < KillCount)
        {
            if (PlayerHasItem || _inventory.HasItem(CheckItem,1))
            {
                _interact.BlinkWhenPlayerNear = true;
                _interact.SetInteractText(HAS_TOOLS);
                PlayerHasItem = true;
            }
            else
            {
                _interact.BlinkWhenPlayerNear = false;
                _interact.SetInteractText(NO_TOOLS);
            }

            count++;
            Debug.Log(count);
        }
        else
            QuakeManager.Instance.TriggerQuake();

    }

    public void Interaction()
    {
        if (!isFalling && PlayerHasItem)
        {
            ObjectiveManager.Instance.Satisfy("BOOKCASE");
            _inventory.RemoveItem(CheckItem, 1);
            QuakeManager.Instance.TriggerCountdown(TriggerTime);
            Disable();
        }
    }
    

    public void Fall()
    {
        if (isFalling) return;
        isFalling = true;
        
        fallCollider.enabled = true;
        rb.isKinematic = false;
        rb.AddRelativeTorque(new Vector3(1,0,0) * fallThrust,ForceMode.VelocityChange);
    }


    private void Disable()
    {
        Destroy(rb);
        Destroy(fallCollider.gameObject.GetComponent<CollisionCallback>());
        Destroy(GetComponent<InteractWithObject>());
        Destroy(GetComponent<BoxCollider>());
        _interact.Kill();
        Destroy(this);
    }


    private void HitPlayer()
    {
        if (!isFalling) return;
        if (rb.velocity.magnitude <= 0) Disable();
        else
        {
            Debug.Log("Player Hit");
            DeathManager.Instance.PlayerDeath("Your bookcase crushed you :(");            
        }
        
    }





}
