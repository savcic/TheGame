using UnityEngine;
using System.Collections;

public class ControlWithoutPhysics : MonoBehaviour
{
	public float moveSpeed = 10f;
	public float rotationSpeed = 50f;
	
	
	void Update ()
	{
		float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
		IncreaseRoationSpeed();
		rotation *= Time.deltaTime;
		transform.Rotate(0,0,rotation);

	}

	void IncreaseRoationSpeed()
	{
		if(Input.GetButtonDown("Horizontal"))
		{
			rotationSpeed *= 2;
		}
	}
}