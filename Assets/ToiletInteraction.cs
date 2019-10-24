using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletInteraction : MonoBehaviour
{
    // Start is called before the first frame update
    public void Interaction()
    {
        gameObject.GetComponent<InteractWithObject>().SetInteractText("Press 'E' to Use Toilet");
        //gameObject.GetComponent<InteractWithObject>().DeleteItems();
        StatusManager.Manager.AffectRelief(50);
    }
}
