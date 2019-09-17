
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMiniGame : MonoBehaviour
{
    // Start is called before the first frame update
	public GameObject wrenchPrefab;
	public GameObject flange; //flange should be a gameobject with a box colider set to trigger and the 

	public Vector3 attachedWrenchPosition;

	GameObject wrench;

	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	void AttachWrench()
	{
		Destroy(wrench.GetComponent<ObjectFollowMouse>());
		flange.GetComponent<CollisionCallback>().RemoveCallback(wrench.tag);
		wrench.transform.position = attachedWrenchPosition;
	}

	public void StartGame()
	{
		if (wrench) return;
		wrench = CreateWrench();
		flange.GetComponent<CollisionCallback>().AddCallback(wrench.tag, AttachWrench);
		
	}

	GameObject CreateWrench()
	{
		var newWrench =  Instantiate(wrenchPrefab, Input.mousePosition, Quaternion.identity);
		newWrench.AddComponent<ObjectFollowMouse>();
		return newWrench;
	}
}
