using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class StartupFollowCam : MonoBehaviour
{
    public CinemachineVirtualCamera cmCam;
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
}
