using MoreMountains.InventoryEngine;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Tooltips : MonoBehaviour
{
    public GameObject tooltip;
    public InventoryDisplay Displayer;
    
    
    private Text _title;
    private Text _body;
    private Transform _tf;

    private Vector2 slotSize;
    private Vector2 padding;
    private int nSlots;

    private int slot;
    private void Start()
    {
        slotSize = Displayer.SlotSize;
        padding = Displayer.SlotMargin;
        nSlots = Displayer.NumberOfColumns;
        if (nSlots <= 0) Destroy(this);
        
        _title = tooltip.transform.Find("Title").GetComponent<Text>();
        _body = tooltip.transform.Find("Body").GetComponent<Text>();
        _tf = tooltip.transform;
        tooltip.SetActive(false);
        
    }

    public void PressTest()
    {
        Debug.Log("Got me");
    }

    public void OnMouseEnter()
    {
        
        if ((slot = GetSlot()) >= 0)
        {
            
        }
        Debug.Log(slot);
    }

    private int GetSlot()
    {
        return (int)((Input.mousePosition.x - transform.position.x) / (nSlots * (slotSize.x+padding.x)));
    }
}
