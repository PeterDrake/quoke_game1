﻿using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

/// <summary>
/// Finds the camera and sets its follow target to the player
/// </summary>
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
