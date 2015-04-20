using UnityEngine;
using System.Collections;

public class MakeItWorkWithMouse : MonoBehaviour {

	private Vector2 startPos;
	private float startPosX;
	private float startPosY;

	private Vector2 endPos;
	private float endPosX;
	private float endPosY;



	private float time;
	private float endTime;
	private float beginTime;

	private float distance;
	private float speed;

	private float horizontal;
	private float vertical;
	// Use this for initialization
	void Start () {
	
	}

	void Update()
	{
		if(Input.GetMouseButtonDown(0))
		{
			startPos = Input.mousePosition;
			startPosX = startPos.x;
			startPosY = startPos.y;
			beginTime = Time.time;

			
		}
		if(Input.GetMouseButtonUp(0))
		{
			endPos = Input.mousePosition;
			endPosX = endPos.x;
			endPosY = endPos.y;
			endTime = Time.time;
			time = endTime - beginTime;
			distance = endPos.y - startPos.y;

			speed = distance/time;
			Debug.Log(speed);
		}

		float x = startPosX - endPosX; //calculate the difference between the 2 touches on the x axis
		//beginning and the  end of the touch, as to be able to assert the direction
		float y = endPosY - startPosY; //calculate the difference between the y axes of the two toches,
		//therefore asserting the direction
		//so that our conditional doesn't always evaluate to true


		if(Mathf.Abs(x) > Mathf.Abs(y))
		{
			horizontal = x > 0 ? 1 : -1; //if x is > 0 to figure out if it's negative or positive therefore getting the direction
			//if it's not greater on the x axis we will set vertical to equal 1 or -1;
			vertical = y > 0 ? 1 : - 1;
		}






	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if(vertical == -1)
		{
			Debug.Log ("-1 so down");
			rigidbody2D.AddTorque(speed);
			//rigidbody2D.AddTorque(-rigidbody2D.angularVelocity * 1f);
			vertical = 0;
		}
		if(vertical == 1)
		{
			Debug.Log ("1 so up");
			rigidbody2D.AddTorque(speed);
			vertical = 0;
		}
		//rigidbody2D.AddTorque(speed,ForceMode2D.Force);
	}
}

/*
 * 
		if(Mathf.Abs(x) > Mathf.Abs(y))
		{
			float horizontal = x > 0 ? 1 : -1; //if x is > 0 to figure out if it's negative or positive therefore getting the direction
			//if it's not greater on the x axis we will set vertical to equal 1 or -1;
			float vertical = y > 0 ? 1 : - 1;
		}
		*/