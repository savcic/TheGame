using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TouchInput : MonoBehaviour
{

		public LayerMask touchInputMask;
		private List<GameObject> touchList = new List<GameObject> ();
		private GameObject[] touchesOld;
		private RaycastHit hit;

#if UNITY_EDITOR


#endif
		// Update is called once per frame
		void Update ()
		{
		
				if (Input.touchCount > 0) {
						//create a new array of type gameobject
						//copy touches made to a placeholder touchesOld
						//clear new list after having copied them
						touchesOld = new GameObject[touchList.Count]; 
						touchList.CopyTo (touchesOld);
						touchList.Clear ();
			
						foreach (Touch touch in Input.touches) { //for every touch in any touch that might get recieved
								Ray ray = camera.ScreenPointToRay (touch.position); //takes a screen point, transforms it so that the ray goes from the 
								//camera's position to the touch position, to see what it's colliding with
								//if true hit will contain more information about where the collider was hit
				
								if (Physics.Raycast (ray, out hit, touchInputMask)) { //casts (ray) against all colliders on touchInputMask
					
										GameObject recipient = hit.transform.gameObject; //create a recipient where we store the transform (location) of the object hit
					
										touchList.Add (recipient); //add the transform recipient to the list
					
										if (touch.phase == TouchPhase.Began) { //if it has been touched
												recipient.SendMessage ("OnTouchDown", hit.point, SendMessageOptions.DontRequireReceiver);  //message send to recipient is method
												//onTouchDown, optional information to not require a receiver, so if this method doesn't exist, it won't kick up a fuss
										}
					
										if (touch.phase == TouchPhase.Ended) {  //button released when finger slips off the button
												recipient.SendMessage ("OnTouchUp", hit.point, SendMessageOptions.DontRequireReceiver);
										}
					
										if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved) {
												recipient.SendMessage ("OnTouchStay", hit.point, SendMessageOptions.DontRequireReceiver);
										}
					
										if (touch.phase == TouchPhase.Canceled) {
												recipient.SendMessage ("OnTouchExit", hit.point, SendMessageOptions.DontRequireReceiver);
										}
								}

						}
						foreach (GameObject g in touchesOld) {
								if (!touchList.Contains (g)) {
										g.SendMessage ("OnTouchExit", hit.point, SendMessageOptions.DontRequireReceiver);
								}
						}
				}
		}
}

