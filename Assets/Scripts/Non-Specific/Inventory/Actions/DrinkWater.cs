public class DrinkWater : ItemAction
{
    public override bool Use(ref Item i)
    {
        if (i.GetType() != typeof(Drinkable)) return false;

        Drinkable d = (Drinkable) i;
        Logger.Instance.Log("Player drank: "+i.name);
        if (d.killPlayer) Death.Manager.PlayerDeath(d.DeathMessage);
        
        StatusManager.Manager.AffectHydration(d.hydrationChange);
        
        //InventoryHelper.Instance.RemoveItem(i);
        return true;
    }
}