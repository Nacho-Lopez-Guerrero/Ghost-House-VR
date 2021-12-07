using UnityEngine;
using System.Collections;

public class TeddyBearHeadStareForce : MonoBehaviour 
{
	private Transform _cameraTransform;
	private float angle = 10;
	public float stearingPlayerTime;
	public float forceX;
	public float forceY;
	public float forceZ;

	private bool activated = false;
	private float _timePassed = 0;
	public GameObject objectToRotate;
	public bool _applyForce;

	// Use this for initialization
	void Start () 
	{
		_cameraTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(activated && Vector3.Angle(transform.position - _cameraTransform.position, _cameraTransform.forward) < angle)
		{
			objectToRotate.GetComponent<RotateObject>().activateRotation = true;
		}

		if(activated && _timePassed > stearingPlayerTime && _applyForce)
		{
			objectToRotate.GetComponent<RotateObject>().activateRotation = false;
			activated = false;
			objectToRotate.gameObject.AddComponent<Rigidbody>();
			objectToRotate.gameObject.GetComponent<Rigidbody>().AddForce(forceX, forceY, forceZ);
		}

		if(objectToRotate.GetComponent<RotateObject>().activateRotation)
			_timePassed += Time.deltaTime;
	}

	void OnTriggerEnter(Collider other) 
	{
		if(other.gameObject.tag == "Player")
		{
			activated = true;
			GetComponent<BoxCollider>().enabled = false;
		}

	}
}
