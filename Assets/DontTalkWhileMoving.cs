using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontTalkWhileMoving : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ImMoving());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator ImMoving()
    {
        GetComponent<CapsuleCollider>().enabled = false;
        yield return new WaitForSeconds(10f);
        GetComponent<CapsuleCollider>().enabled = true;

    }
}
