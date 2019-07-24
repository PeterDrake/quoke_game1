using System.Collections;
using System.Collections.Generic;
using MoreMountains.InventoryEngine;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class DontTalkWhileMoving : MonoBehaviour
{
    public GameObject ThisCharacter;

    public GameObject AItarget;

    public GameObject dialogueManager;

    public GameObject interactEnabler;
  

    public void ConversationOver()
    {
        StartCoroutine(ImMoving());
        ThisCharacter.GetComponent<AICharacterControl>().target = AItarget.transform;
        dialogueManager.GetComponent<DialogueManager>().NPCL3 = false;



    }
    

    public IEnumerator ImMoving()
    {
        GetComponent<CapsuleCollider>().enabled = false;
        interactEnabler.SetActive(false);
        yield return new WaitForSeconds(15.5f);
        GetComponent<CapsuleCollider>().enabled = true;
        

    }
}
