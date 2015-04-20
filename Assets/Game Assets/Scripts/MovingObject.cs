using UnityEngine;
using System.Collections;

public abstract class MovingObject : MonoBehaviour { //class members incomplete and must be implemented

	public float moveTime = 0.1f;
	public LayerMask blockingLayer;

	private BoxCollider2D boxCollider;
	private Rigidbody2D rb2d;
	private float inverseMoveTime; //to make movement calculations more efficient
	// Use this for initialization
	protected virtual void Start () { //protected virtual functions can be overriden by their inherited classes 
		//(so that inherited classes can have a different implementation of Start
		boxCollider = GetComponent<BoxCollider2D>();
		rb2d = GetComponent<Rigidbody2D>();
		inverseMoveTime = 1f / moveTime;

	}

	protected bool Move (int xDir, int yDir, out RaycastHit2D hit) //out passed by reference, more than one value and we are also returning are raycasthit2d
	{
		Vector2 start = transform.position;
		Vector2 end = start + new Vector2 (xDir,yDir);

		boxCollider.enabled = false; // we disable the collider so that the ray doesn't hit itself
		hit = Physics2D.Linecast(start,end,blockingLayer); //returns true if any collider intersects the line between start and end
		boxCollider.enabled = true;

		if(hit.transform == null) //if the space we cast our line was open
		{
			StartCoroutine(SmoothMovement(end)); //start going towards that object
			return true; //we were able to move
		}
		return false; //we weren't

	}

	protected IEnumerator SmoothMovement (Vector3 end)
	{
		float sqrRemainingDistance = (transform.position - end).sqrMagnitude; //cheaper than magnitude

		while(sqrRemainingDistance > float.Epsilon)
		{
			Vector3 newPosition = Vector3.MoveTowards (rb2d.position,end,inverseMoveTime * Time.deltaTime); //in a straight line towards a target point, 
			//we are going to move between our current position, the end
			rb2d.MovePosition(newPosition);
			sqrRemainingDistance = (transform.position - end).sqrMagnitude;
			yield return null; //wait for a frame before re-evaluating the condition of the loop
		}
	}

	protected virtual void AttemptMove<T>(int xDir, int yDir) //generic paramater T
		//used to specify the type of component we expect our component to interact with if blocked
		//in case of enemies player, in case of player walls so that player can attack walls
		where T: Component //we specify T is a component
	{
		RaycastHit2D hit;
		bool canMove = Move (xDir,yDir, out hit); //canMove true if move succesful, false if it failed
		//the fact that Hit is an out parameter for move, allows us to check if the transform that we hit
		//in move is null, if nothing was hit by our linecast in move we're gonna return and not execute
		//if it was hit, we'll get a component reference of type T attached to the object that was hit
		//if can move 

		if(hit.transform == null)
			return;

		T hitComponent = hit.transform.GetComponent<T>(); //if something was hit we get component reference of component type T of object hit

		if(!canMove && hitComponent != null) //if we can't move and it was blocked
		{
			OnCantMove(hitComponent);
		}

		//the reason we use generic is so that both enemy and player can move, we don't know in advance what type of hit component they're interacting with
	}

	protected abstract void OnCantMove <T>(T component) //takes a generic parameter T and and type T component
	//missing or incomplete implementation, will be overriden in other classes
		where T : Component;
	
}
