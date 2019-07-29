using System.Collections;
using System.Collections.Generic;
using MoreMountains.InventoryEngine;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class DontTalkWhileMoving : MonoBehaviour
{

    /// <summary>
    ///  A script which sends level 3 NPC 1 to their house (player follows), also makes sure player can't disrupt the NPC while they're moving
    /// </summary>
    public GameObject ThisCharacter;

    public GameObject AItarget;

    public GameObject dialogueManager;

    public GameObject interactEnabler;


    //NPC starts moving after the first conversation ends
    public void ConversationOver()
    {
        StartCoroutine(ImMoving());
        ThisCharacter.GetComponent<AICharacterControl>().target = AItarget.transform;
        dialogueManager.GetComponent<DialogueManager>().NPCL3 = false;
        
    }
    
    //NPC wont talk to you until they are done traveling to target location
    public IEnumerator ImMoving()
    {
        GetComponent<CapsuleCollider>().enabled = false;
        interactEnabler.SetActive(false);
        yield return new WaitForSeconds(13f);
        GetComponent<CapsuleCollider>().enabled = true;
        

    }
}
