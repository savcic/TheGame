using UnityEngine;
using System.Collections;

public class TestScript : MonoBehaviour {

	Vector2 distanceMeasuredInScreenWidths;
	Vector2 speedMeasuredInScreenWidths;



	public LayerMask touchInputMask;
	private int ignoreMask;


	
	private Ray originRay;
	private RaycastHit theHit;

	
	private Vector3 onTHINGPointBegin;
	private Vector3 onTHINGPointEnd;

	private Vector3 startedAtGlasswise;


	//------------------------------------------

	private float touchBeginTime,touchEndTime; 

	private float speed;
	private float deceleration;


	void Start () {
	
	}

	// Update is called once per frame
	void Update () {


		if(Input.touchCount > 0)
		{
			Touch myTouch = Input.touches[0];

		
			if(myTouch.phase == TouchPhase.Moved)
			{
				speed = myTouch.deltaPosition.magnitude / myTouch.deltaTime;
				speed = speed/10; 
			}
			
			if(myTouch.phase == TouchPhase.Began)
			{
				//Debug.Log("TOUCH PHASE BEGIN");
				touchBeginTime = myTouch.deltaTime;
			}

			if(myTouch.phase == TouchPhase.Ended)
			{
				touchEndTime = myTouch.deltaTime;
				Debug.Log("THIS IS THE SPEED" + speed);
				speed = 0f;
			}

			// you can calculate the touch's speed of motion by dividing deltaPosition.magnitude by deltaTime.

			//speed = myTouch.deltaPosition.magnitude / myTouch.deltaTime;

			Debug.Log("THIS IS THE SPEED" + speed);


		}
	}

	void FixedUpdate()
	{
		rigidbody2D.AddTorque(speed,ForceMode2D.Force);
	}




		/*
		if ( Input.touches.Length != 1 ) return;

		if ( Input.touches[0].phase != TouchPhase.Moved ) return;

		if (Input.touches[0].deltaTime == 0.0) return;

		distanceMeasuredInScreenWidths = Input.touches[0].deltaPosition / Screen.width;
		speedMeasuredInScreenWidths = distanceMeasuredInScreenWidths / Input.touches[0].deltaTime;


		originRay = Camera.main.ScreenPointToRay( Input.touches[0].position );
		Debug.Log("This is the ray  " + originRay);
		//if ( ! collider.Raycast (originRay, out theHit, 10f )) return;


		startedAtGlasswise = Input.touches[0].position - Input.touches[0].deltaPosition;

		onTHINGPointBegin = theHit.point;

		if(collider.Raycast(originRay, out theHit, touchInputMask))
		{
			
			Debug.Log("<color=red>Fatal error:</color>I AM TOUCHING THIS!");



			//moveLikeThisInRealWorld( (onTHINGPointEnd - onTHINGPointBegin) / Input.touches[0].deltaTime );



		}
	}

	public void moveLikeThisInRealWorld(Vector3 where)
	{
		transform.position = where;

	}

	public void processOneSmallMove(Vector2 vector)
	{
		vector = Input.touches[0].deltaPosition / Input.touches[0].deltaTime;
	}
*/

}
