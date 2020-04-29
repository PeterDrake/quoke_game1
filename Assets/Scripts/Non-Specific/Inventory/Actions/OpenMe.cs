
using UnityEngine;

[CreateAssetMenu(fileName = "New Open Action", menuName = "Items/Actions/Open")]
public class OpenMe : ItemAction
{

    public override bool Use(ref Item i)
    { 
        return true;
    }
}