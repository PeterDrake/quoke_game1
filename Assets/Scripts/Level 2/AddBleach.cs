using UnityEngine;

[CreateAssetMenu(fileName = "New Bleach Action", menuName = "Items/Actions/Bleach")]
public class AddBleach : ItemAction
{
    
    public override bool Use(ref Item i)
    {
        Item item;
        if (InventoryHelper.Instance.HasItem((item = Resources.Load<Item>("items/DirtyWater")),1))
        {
            InventoryHelper.Instance.RemoveItem(item,1);
            InventoryHelper.Instance.AddItem(Resources.Load<Item>("items/BleachWater4"), 1);
        }
        else if (InventoryHelper.Instance.HasItem(item = Resources.Load<Item>("items/BleachWater4"), 1))
        {
            InventoryHelper.Instance.RemoveItem(item,1);
            InventoryHelper.Instance.AddItem(Resources.Load<Item>("items/BleachWater12"), 1);
        }
        else if (InventoryHelper.Instance.HasItem(item = Resources.Load<Item>("items/BleachWater8"), 1))
        {
            InventoryHelper.Instance.RemoveItem(item,1);
            InventoryHelper.Instance.AddItem(Resources.Load<Item>("items/BleachWater12"), 1);
        }
        else if (InventoryHelper.Instance.HasItem(item = Resources.Load<Item>("items/BleachWater12"), 1))
        {
            InventoryHelper.Instance.RemoveItem(item,1);
            InventoryHelper.Instance.AddItem(Resources.Load<Item>("items/BleachWater16"), 1);
        }
        else if (InventoryHelper.Instance.HasItem(item = Resources.Load<Item>("items/BleachWater16"), 1))
        {
            InventoryHelper.Instance.RemoveItem(item,1);
            InventoryHelper.Instance.AddItem(Resources.Load<Item>("items/BleachWater"), 1);
        }

        return false;
    }
}
