
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMiniGame : MonoBehaviour
{
    // Start is called before the first frame update
	public GameObject wrenchPrefab;
	public GameObject flange; //flange should be a gameobject with a box colider set to trigger and the 

	public Vector3 attachedWrenchPosition;
	public float z_offset;

	public float flangeRotationUpperBound = -5f;
	public float flangeRotationlowerBound = 95f;
	public float targetRotation = 90f;
	public float targetThreshold = 2f;

	GameObject wrench;

	void Start()
    {
        //attachedWrenchPosition = ;
	}

    // Update is called once per frame
    void Update()
    {
        
    }

	void success()
	{
		Debug.Log("Congratz, you have won!");
		Destroy(flange.GetComponent<RotateObjectWithMouse>());
	}

	void AttachWrench()
	{
		flange.GetComponent<CollisionCallback>().RemoveCallback(wrench.tag);
		Destroy(wrench);
		flange.transform.GetChild(0).gameObject.SetActive(true);
		var comp = flange.AddComponent<RotateObjectWithMouse>();
		comp.Initialize(flangeRotationlowerBound, flangeRotationUpperBound, targetRotation, targetThreshold, success);
	}

	public void StartGame()
	{	
		if (wrench) return;
		wrench = CreateWrench();
		flange.GetComponent<CollisionCallback>().AddCallback(wrench.tag, AttachWrench);
	}

	GameObject CreateWrench()
	{
		var newWrench =  Instantiate(wrenchPrefab, new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z + z_offset), Quaternion.identity);
		newWrench.AddComponent<ObjectFollowMouse>();
		return newWrench;
	}
}
