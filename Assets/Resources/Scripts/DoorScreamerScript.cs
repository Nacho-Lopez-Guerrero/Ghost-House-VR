using UnityEngine;
using System.Collections;

public class DoorScreamerScript : MonoBehaviour {
	
	public GameObject fantasma;
	public Transform spawnGhostTransform;
	private bool spawned = false;
	
	void  Start ()
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	
	void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "Player" && !spawned)
		{
			//encender sonido contestador
			spawned = true;
			//instanciar fantasma inclinado
			GameObject screamerGhost = Instantiate(fantasma, spawnGhostTransform.position, spawnGhostTransform.rotation) as GameObject;
			screamerGhost.transform.parent = spawnGhostTransform;
		}
	}
}
