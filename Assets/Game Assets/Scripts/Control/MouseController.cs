using UnityEngine;
using System.Collections;

public class MouseController : MonoBehaviour {

	public float jetpackForce = 75f;
	public float forwardMovementSpeed = 3f;

	// Use this for initialization
	void Start () {
	
	}
	/**
	if (touch.position.x < Screen.width/2)
	{
		transf
		
		transform.rotation = Quaternion.Lerp ( transform.rotation, Quaternion.Euler(0,0, 25), Time.deltaTime*lSpeed);
		//transform.rotation = Quaternion.Euler(0,0,120);
		Debug.Log("RotateRight");
	}
	else if (touch.position.x > Screen.width/2)
	{
		transform.rotation = Quaternion.Lerp ( transform.rotation, Quaternion.Euler(0,0,300), Time.deltaTime*lSpeed);
		//transform.rotation = Quaternion.Euler(0,0,-120);
		Debug.Log("RotateLeft");
	}
*/

	void FixedUpdate () { //all physics related code goes here

		/**
		bool jetPackActive = Input.GetButton("Fire1"); //if screen is touched

		if(jetPackActive)
		{
			rigidbody2D.AddForce(new Vector2(0, jetpackForce)); //applies force to the rigidbody
		}
		*/

		Vector2 newVelocity = rigidbody2D.velocity;
		newVelocity.y = forwardMovementSpeed;
		rigidbody2D.velocity = newVelocity;
	
	}



}

/*
 * Touch touch;

	void Update()
	{
		if (touch.position.x < Screen.width/2)
		{

			transform.Translate(new Vector2 (30,transform.position.y));	
			//transform.position
			//transform.rotation = Quaternion.Euler(0,0,120);
			Debug.Log("RotateRight");
		}
		else if (touch.position.x > Screen.width/2)
		{
			transform.rotation = Quaternion.Lerp ( transform.rotation, Quaternion.Euler(0,0,300), Time.deltaTime);
			//transform.rotation = Quaternion.Euler(0,0,-120);
			Debug.Log("RotateLeft");
		}
	}*/