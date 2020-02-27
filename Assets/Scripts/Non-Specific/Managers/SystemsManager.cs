using UnityEngine;

public class SystemsManager : MonoBehaviour
{
    public static SystemsManager Systems;
    public DialogueManager Dialogue;
    public InventoryHelper Inventory;
    public ObjectiveManager Objectives;
    public StatusManager Status;
    public UIManager UI;
    public PauseManager Pause;
    public InputManager Input;

    private void Awake()
    {
        if (Systems == null) Systems = this;
        else Destroy(this);

        Dialogue = GetComponent<DialogueManager>();
        if (Dialogue == null) gameObject.AddComponent<DialogueManager>();
        
        Inventory = GetComponent<InventoryHelper>();
        if (Inventory == null) gameObject.AddComponent<InventoryHelper>();
        
        Objectives = GetComponent<ObjectiveManager>();
        if (Objectives == null) gameObject.AddComponent<ObjectiveManager>();
        
        Status = GetComponent<StatusManager>();
        if (Status == null) gameObject.AddComponent<StatusManager>();

        UI = GetComponent<UIManager>();
        if (UI == null) gameObject.AddComponent<UIManager>();
        
        Pause = GetComponent<PauseManager>();
        if (Pause == null) gameObject.AddComponent<PauseManager>();
        
        Input = GetComponent<InputManager>();
        if (Input == null) gameObject.AddComponent<InputManager>();
        
    }
}
