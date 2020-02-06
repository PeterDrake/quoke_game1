using UnityEngine;

[CreateAssetMenu(fileName = "New Drinkable Item", menuName = "Dialogue/Drinkable")]
public class Drinkable : Item
{
    public int hydrationChange = 0;
    public bool killPlayer;
    public string DeathMessage;

}