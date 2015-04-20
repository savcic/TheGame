using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RoomGeneration : MonoBehaviour {
	/**
	 * The idea behind the generator script is quite simple. The script that has an array of rooms it can generate, a list of rooms currently generated, and two additional methods. 
	 * One method checks to see if another room needs to be added and the other method actually adds room.
To check if a room needs to be added, the script will enumerate all existing rooms and see if there is a room ahead, farther then the screen width, 
to guarantee that the player never sees the end of the level.
rocket_mouse_unity_p2_37
As you can see in case #1 you don’t need to add a room yet, since the end of the last room is still far enough from the player. And in case #2 you should already add a room.
*/
	
	public GameObject[] availableRooms;
	/*The availableRooms will contain an array of Prefabs, which the script can generate. 
	 * Currently you have only one Prefab (room1). But you can create many different room types and add them all to this array, so that 
	 * the script could randomly choose which room type to generate.
	*/

	public List<GameObject> currentRooms;
	/*The currentRooms list will store instanced rooms, so that it can check where the last room ends 
	 * and if it needs to add more rooms. Once the room is behind the player character, it will remove it as well.
	 * */

	//private float screenWidthInPoints; //The screenWidthInPoints variable is just required to cache screen size in points.
	private float screenHeightInPoints;

	public void Start()
	{
		float height = 2.0f * Camera.main.orthographicSize;
		screenHeightInPoints = height;

		//float height = 2f * Camera.main.orthographicSize;
		//screenWidthInPoints = height * Camera.main.aspect;
	}

	//void AddRoom(float farthestRoomEndX)
	void AddRoom(float farthestRoomEndY)
	{
		//1
		int randomRoomIndex = Random.Range(0, availableRooms.Length);
		
		//2
		GameObject room = (GameObject)Instantiate(availableRooms[randomRoomIndex]);
		
		//3
		//float roomWidth = room.transform.FindChild("floor").localScale.x;
		float roomHeight = room.transform.FindChild("height").localScale.y;
		
		//4
		//float roomCenter = farthestRoomEndX + roomWidth * 0.5f;
		float roomCenter = farthestRoomEndY + roomHeight * 0.5f;
		//5
		room.transform.position = new Vector3(0, roomCenter, 0);
		
		//6
		currentRooms.Add(room);         
	}

	void GenerateRoomIfRequired()
	{
		//1
		List<GameObject> roomsToRemove = new List<GameObject>();
		
		//2
		bool addRooms = true;        
		
		//3
		//float playerX = transform.position.x;
		float playerY = transform.position.y;
		//4
		//float removeRoomX = playerX - screenWidthInPoints; 
		float removeRoomY = playerY - screenHeightInPoints;        
		
		//5
		//float addRoomX = playerX + screenWidthInPoints;
		float addRoomY = playerY + screenHeightInPoints;
		//6
		//float farthestRoomEndX = 0;
		float farthestRoomEndY = 0;
		
		foreach(var room in currentRooms)
		{
			//7
			//float roomWidth = room.transform.FindChild("floor").localScale.x;
			float roomHeight = room.transform.FindChild("height").localScale.y;
			//float roomStartX = room.transform.position.x - (roomWidth * 0.5f); 
			float roomStartY = room.transform.position.y - (roomHeight * 0.5f);
			//float roomEndX = roomStartX + roomWidth;  
			float roomEndY = roomStartY + roomHeight;
			
			//8
			//if (roomStartX > addRoomX)
			if (roomStartY > addRoomY) //
				addRooms = false;
			
			//9
			//if (roomEndX < removeRoomX)
			if (roomEndY < removeRoomY) //<addRoomY
				roomsToRemove.Add(room);


			//10
			//farthestRoomEndX = Mathf.Max(farthestRoomEndX, roomEndX);
			farthestRoomEndY = Mathf.Max(farthestRoomEndY, roomEndY);
		}
		
		//11
		foreach(var room in roomsToRemove)
		{
			currentRooms.Remove(room);
			Destroy(room);            
		}
		
		//12
		if (addRooms)
			AddRoom(farthestRoomEndY);
	}

	void FixedUpdate () 
	{    
		GenerateRoomIfRequired();
	}

}
