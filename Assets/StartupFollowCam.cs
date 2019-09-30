using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class StartupFollowCam : MonoBehaviour
{
    public CinemachineVirtualCamera cmCam;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FollowPlayer());
    }

    public IEnumerator FollowPlayer()
    {
        yield return new WaitForEndOfFrame();
        GameObject myPlayer = GameObject.FindWithTag("Player");
        cmCam.Follow = myPlayer.transform;

    }
    // Update is called once per frame
    void Update()
    {
        
    }
    
    
}
