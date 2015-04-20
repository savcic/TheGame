using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ControlPlayer : MonoBehaviour
{

	int horizontal = 0;
	int vertical = 0;

	private Vector2 touchOrigin = -Vector2.one; //record place where user finger started placing the finger 
	//it's minus because it's out of the string, because it is not touched unless the Vector exists.
	
	void Update()
	{
		if(Input.touchCount > 0) //if any touches have been made
		{
			Touch myTouch = Input.touches[0]; //we will record the touch (myTouch) in the first box of the array touches
			//this is because it's gonna support a single finger in the cardinal directions
			
			if(myTouch.phase == TouchPhase.Began) //if touching has began
			{
				touchOrigin = myTouch.position; //the origin of the touch is equal to the touch i'm currently making
			}
			
			else if(myTouch.phase == TouchPhase.Ended && touchOrigin.x >= 0) //if the touch phase has ended and if the
				//inside the bounds of the screen and has changed
			{
				Vector2 touchEnd = myTouch.position;
				float x = touchEnd.x - touchOrigin.x; //calculate the difference between the 2 touches on the x axis
				//beginning and the  end of the touch, as to be able to assert the direction
				float y = touchEnd.y - touchOrigin.y; //calculate the difference between the y axes of the two toches,
				//therefore asserting the direction
				touchOrigin.x = -1; //so that our conditional doesn't always evaluate to true
				
				if(Mathf.Abs(x) > Mathf.Abs(y))
				{
					horizontal = x > 0 ? 1 : -1; //if x is > 0 to figure out if it's negative or positive therefore getting the direction
					//if it's not greater on the x axis we will set vertical to equal 1 or -1;
					vertical = y > 0 ? 1 : - 1;
				}
				
				//if(horizontal != 0 || vertical != 0) 
					//AttemptMove<Wall> (horizontal,vertical);

			}
		}
	}
}