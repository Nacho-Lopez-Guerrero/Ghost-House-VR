using UnityEngine;
using System.Collections;

public class PhoneScript : MonoBehaviour {

	public float waitingTime = 0.05f;
	public Light light;
	public GameObject fantasma;
	public Transform Spawnfantasma;
	private bool contestado = false;

	IEnumerator Start ()
	{
		while (!contestado)
		{
			light.enabled = !(light.enabled); //toggle on/off the enabled property
			yield return new WaitForSeconds(waitingTime);
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "Player" && !contestado)
		{
			light.enabled = false;
			//encender sonido contestador
			contestado = true;
			//instanciar fantasma inclinado
			Instantiate(fantasma, Spawnfantasma.position, Spawnfantasma.rotation);
		}
	}
}
