using UnityEngine;
using System.Collections;

public class AutoDestroy : MonoBehaviour 
{

	public float timeToDestroy;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(timeToDestroy <= 0)
			Destroy(gameObject);
		else
			timeToDestroy -= Time.deltaTime;
	}
}
