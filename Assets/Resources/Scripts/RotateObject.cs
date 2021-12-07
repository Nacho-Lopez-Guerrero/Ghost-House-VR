using UnityEngine;
using System.Collections;

public class RotateObject : MonoBehaviour {

	private Transform _cameraTransform;

	public bool activateRotation = false;

	// Use this for initialization
	void Start () 
	{
		_cameraTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(activateRotation)
		{
			Vector3 relativePos = _cameraTransform.position - transform.position;
			Quaternion targetRotation = Quaternion.LookRotation(relativePos);

			transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 2.0f);    

		}


	}

	public void InstantRotate()
	{
		Vector3 relativePos = _cameraTransform.position - transform.position;
		Quaternion targetRotation = Quaternion.LookRotation(relativePos);
		transform.rotation = targetRotation;
	}
}
