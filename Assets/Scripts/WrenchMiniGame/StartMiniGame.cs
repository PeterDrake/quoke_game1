
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMiniGame : MonoBehaviour
{
	public GameObject wrenchPrefab;
	public GameObject flange; 

	public Vector3 attachedWrenchPosition;
	public float z_offset;

	public float flangeRotationUpperBound = -5f;
	public float flangeRotationlowerBound = 95f;
	public float targetRotation = 90f;
	public float targetThreshold = 2f;

	private GameObject wrench;

	private bool started = false;

	private void Success()
	{
		//replace this with success action, i.e. turn off gas
		Debug.Log("Congratz, you have won!");
		Destroy(flange.GetComponent<RotateObjectWithMouse>());
	}

	private void AttachWrench()
	{
		flange.GetComponent<CollisionCallback>().RemoveCallback(wrench.tag);
		Destroy(wrench);
		flange.transform.GetChild(0).gameObject.SetActive(true);
		var comp = flange.AddComponent<RotateObjectWithMouse>();
		comp.Initialize(flangeRotationlowerBound, flangeRotationUpperBound, targetRotation, targetThreshold, Success);
	}

	public void StartGame()
	{
		if (!started)
		{
			started = true;
			wrench = CreateWrench();
			flange.GetComponent<CollisionCallback>().AddCallback(wrench.tag, AttachWrench);
		}
	}

	private GameObject CreateWrench()
	{
		var newWrench =  Instantiate(wrenchPrefab, new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z + z_offset), Quaternion.identity);
		newWrench.AddComponent<ObjectFollowMouse>();
		return newWrench;
	}
}
