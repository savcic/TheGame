using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public GameObject targetObject;
	private float distanceToTarget;
	// Use this for initialization

	void Start () {
		distanceToTarget = transform.position.y - targetObject.transform.position.y; //calculates the distance of the camera to the player

	}

	// Update is called once per frame
	void Update () {

		float targetObjectY = targetObject.transform.position.y; //get the .x value of the transform of the player
		Vector3 newCameraPosition = transform.position; //create a new vector to store the camera's position
		newCameraPosition.y = targetObjectY + distanceToTarget; //x position of camera = .x value of tranform of player
		transform.position = newCameraPosition; //store the changed value of position in the transform of the camera

	}
}
