using UnityEngine;
using System.Collections;

public class KnifeStareForce : MonoBehaviour 
{
	private Transform _cameraTransform;
	private float angle = 10;
	public float levitateTime;
	public float forceX;
	public float forceY;
	public float forceZ;

	private bool activated = false;
	private float _timePassed = 0;
	public GameObject objectToRotate;
	public bool _applyForce;
	private bool _alreadyFacing = false;

	// Use this for initialization
	void Start () 
	{
		_cameraTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(activated && !_alreadyFacing)
		{
			//objectToRotate.GetComponent<RotateObject>().activateRotation = true;
			GetComponent<RotateObject>().InstantRotate();

			GetComponent<Animation>().Play();
			_alreadyFacing = true;
		}

		if(activated && _timePassed > levitateTime && _applyForce)
		{
			GetComponent<Animation>().Stop();

			Debug.LogError("Fuerza aplciacda");
			//objectToRotate.GetComponent<RotateObject>().activateRotation = false;
			GetComponent<RotateObject>().InstantRotate();
			activated = false;

			gameObject.AddComponent<Rigidbody>();
			gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * forceZ);
		}

		if(activated)
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
