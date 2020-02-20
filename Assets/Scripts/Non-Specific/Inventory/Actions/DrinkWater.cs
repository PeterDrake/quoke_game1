
using UnityEngine;

[CreateAssetMenu(fileName = "New Drink Water Action", menuName = "Items/Actions/Drink")]
public class DrinkWater : ItemAction
{
    
    public override bool Use(ref Item i)
    {
        if (i.GetType() != typeof(Drinkable)) return false;

        Drinkable d = (Drinkable) i;
        Logger.Instance.Log("Player drank: "+i.name);
        if (d.killPlayer) DeathManager.Instance.PlayerDeath(d.DeathMessage);
        StatusManager.Manager.AffectHydration(d.hydrationChange);
        
        InventoryHelper.Instance.RemoveItem(i,1);
        return true;
    }
}