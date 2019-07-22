using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class DontTalkWhileMoving : MonoBehaviour
{
    public GameObject ThisCharacter;

    public GameObject AItarget;
    // Start is called before the first frame update
    void Start()
    {
      //  StartCoroutine(ImMoving());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ConversationOver()
    {
        StartCoroutine(ImMoving());
        ThisCharacter.GetComponent<AICharacterControl>().target = AItarget.transform;


    }
    

    public IEnumerator ImMoving()
    {
        GetComponent<CapsuleCollider>().enabled = false;
        yield return new WaitForSeconds(14f);
        GetComponent<CapsuleCollider>().enabled = true;

    }
}
