using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	private GameObject player;
	public float turnSpeed = 3f;
	public float speed;


	// Use this for initialization
	void Start () {
	
		player = GameObject.Find("mouse_fly");

	}
	
	// Update is called once per frame
	void Update () {
	

		if(Input.GetKey(KeyCode.D)) {
			// Clockwise
			//transform.Translate(new Vector2(-1f,transform.position.y)* Time.deltaTime) ;
			transform.Rotate(0, 0, -turnSpeed);

			 // --> Instead of "transform.Rotate(-1.0f, 0.0f, 0.0f);"
		}
		
		if(Input.GetKey(KeyCode.A)) {
			// Counter-clockwise
			//transform.Rotate(0, 0, turnSpeed); // --> Instead of transform.Rotate(1.0f, 0.0f, 0.0f);

			transform.Rotate(0, 0, turnSpeed);

		}

		if(Input.GetKey(KeyCode.W)) {


			transform.Translate(new Vector2(speed,0)* Time.deltaTime) ;
		}

		if(Input.GetKey(KeyCode.S)) {
			transform.Translate(new Vector2(-speed,0)* Time.deltaTime) ;
		}
	}
}




