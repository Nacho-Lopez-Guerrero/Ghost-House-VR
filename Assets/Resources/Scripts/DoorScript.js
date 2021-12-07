#pragma strict

var open : boolean = false;

var openAnimationString : String;
var closeAnimationString : String;

var buttonTransform : Transform;
var distToOpen : float = 4;

@HideInInspector
var playerTransform : Transform;
@HideInInspector
var cameraTransform : Transform;

var openSound : AudioClip;
var closeSound : AudioClip;

function Awake ()
{
	playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
	cameraTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;
	if(open)
		GetComponent.<Animation>().Play(openAnimationString);
	
	if(playerTransform != null)
		Debug.Log(playerTransform);
	if(cameraTransform != null)
		Debug.Log(cameraTransform);
}

function Start () {

}

function Update () 
{
	var alreadyChecked : boolean = false;
	var angle : float = 45;
	if(Vector3.Distance(playerTransform.position, buttonTransform.position) <= distToOpen)
	if(Vector3.Angle(buttonTransform.position - cameraTransform.position, cameraTransform.forward) < angle)
	{
		Debug.Log("Use key presed!");
		if(Input.GetButtonDown("Use"))
		{
			if(!open)
			{
			GetComponent.<Animation>().Play(openAnimationString);
			open = true;
			if(openSound)
					GetComponent.<AudioSource>().PlayOneShot(openSound);
			}
			else
			{
				GetComponent.<Animation>().Play(closeAnimationString);
				open = false;
				if(openSound)
					GetComponent.<AudioSource>().PlayOneShot(openSound);
			}
		}
	}
}