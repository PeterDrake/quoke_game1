
using UnityEngine;

[CreateAssetMenu(fileName = "New Drink Water Action", menuName = "Items/Actions/Drink")]
public class DrinkWater : ItemAction
{
    
    public override bool Use(ref Item i)
    {
        if (i.GetType() != typeof(Drinkable)) return false;

        Drinkable d = (Drinkable) i;
        Logger.Instance.Log("Player drank: "+i.name);
        if (d.killPlayer) Systems.Status.PlayerDeath(d.DeathMessage);
        Systems.Status.AffectHydration(d.hydrationChange);
        
        return true;
    }
}