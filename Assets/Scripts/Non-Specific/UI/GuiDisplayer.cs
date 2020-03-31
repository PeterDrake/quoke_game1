using UnityEngine;

/// <summary>
/// A manager to keep track of GUI elements (status bars, text banner, interact text & misc buttons (inventory))
/// </summary>
public class GuiDisplayer : UIElement
{
    private GameObject toggler;
    [SerializeField] private InformationCanvas Banner;
    [SerializeField] private InformationCanvas Interact;
    
    private void Start()
    {
        toggler = transform.Find("GUIToggler").gameObject;
       UIManager.Instance.Initialize(this);
    }

    public override void Open()
    {
        toggler.SetActive(true);
    }

    public override void Close()
    {
        toggler.SetActive(false);
    }

    public InformationCanvas GetBanner()
    {
        return Banner;
    }
    
    public InformationCanvas GetInteract()
    {
        return Interact;
    }
}