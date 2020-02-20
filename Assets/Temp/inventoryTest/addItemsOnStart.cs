using UnityEngine;

public class addItemsOnStart : MonoBehaviour
{
    public Item[] itemsToAdd;
    public byte[] amounts;

    private void Start()
    {
        int i = 0;
        foreach (Item item in itemsToAdd)
        {
            InventoryHelper.Instance.AddItem(item, amounts[i]);
            i++;
        }
    }
    
}
