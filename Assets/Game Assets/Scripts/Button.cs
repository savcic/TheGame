using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

	public LayerMask touchInputMask;

	private Vector3 targetPos; //pozitia in care vrem sa ajunga

	public Camera camera;

	private Vector2 touchOrigin = -Vector2.one;
	private Vector2 touchEnd = -Vector2.one;
	private float timeTouchBegin;
	private float timeTouchEnd;
	private float touchSpeed;
	private Vector2 touchDistance;

	private Ray originRay;
	private RaycastHit theHit;

	void Update()
	{
		//if ( Input.touches.Length != 1 ) return;
		//if ( Input.touches[0].phase != TouchPhase.Moved ) return;
		//if ( Input.touches[0].deltaTime == 0.0 ) return;


		// you can calculate the touch's speed of motion by dividing deltaPosition.magnitude by deltaTime.

		if (Input.touchCount > 0)
		{
			Touch touch =  Input.touches[0];

			if(touch.phase == TouchPhase.Began)
			{
				Debug.Log("TOUCHPHASE BEGAN");
				touchOrigin = touch.position;
				timeTouchBegin = Time.time;
			}

			if(touch.phase == TouchPhase.Moved)
			{

			}

			if(touch.phase == TouchPhase.Ended)
			{
				Debug.Log("TOUCHPHASE ENDED");
				touchEnd = touch.position;
				timeTouchEnd = Time.time;
			}
			//////////////////////////////////////////////////////
			//touch.phase == TouchPhase.Moved

			

			touchDistance = touchEnd - touchOrigin;
			Debug.Log("This is the distance: " + touchDistance);

			touchSpeed = timeTouchEnd - timeTouchBegin;
			Debug.Log("This is the speed: " + touchSpeed);
				


			originRay = camera.ScreenPointToRay( Input.touches[0].position );

			if(collider.Raycast(originRay, out theHit, touchInputMask))
			{
				
				Debug.Log("<color=red>Fatal error:</color>I AM TOUCHING THIS!");
			}
			//transform.position = touchSpeed * touchDistance;
			//////////////////////////////////////////////////////


		}
	}


	void Start()
	{

	}
}
