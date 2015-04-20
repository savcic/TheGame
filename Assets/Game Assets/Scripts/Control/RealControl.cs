using UnityEngine;
using System.Collections;

public class RealControl : MonoBehaviour {

	public float speed;
	public float multiplier;

	private float moveHorizontal;
	private Rigidbody2D rb;
		
	// Use this for initialization
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		moveHorizontal = Input.GetAxis("Horizontal");

		Vector2 movement = new Vector2(moveHorizontal,transform.position.y);

		//rb.AddForce(movement * speed);

		rb.AddTorque(moveHorizontal * speed);

	}
}
