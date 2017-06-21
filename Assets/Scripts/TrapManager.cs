using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Collections;
public class TrapManager : MonoBehaviour {

	//grid attributes 
	public bool spawnGrid;	public int maxFloorTiles = 10;

	public bool spawnRnd; public int maxTotalTraps =  20;
	public List<Vector3> postions; //for random 
	public int x_dimention, y_dimention;
	public static int x = 2 ,y = 2;
	//counters 
	int butn;
	int spiks;
	int snakes;
	int pits;

	public float minxyDistance= 5;
	public GameObject[] prefabTraps = new GameObject[4];
	bool IsCloseToTrap;
	//for grid based lists - lists incase we move them out for now 
	public List<Vector3> postionsNew;
	public List<Vector3> groundPositions;
	public List<Vector3> trapPostions;
	Vector3[] temp;


	//add all four types as prefabs array 
	//noot noot
	// Use this for initialization
	void Start () {
		x = x_dimention -1 ;
		y = y_dimention-1; //change this into setter/getter method 


		//spawning by random placments 
		if (spawnRnd) {
			spawnTraps ();
		}
	//	Debug.Log ("number of button traps is " + butn + "number of pits traps is " + pits + "number of spikes traps is " + spiks + "number of button snales is " + snakes);
	
		//spawning by grids 
		if (spawnGrid) {
			CreateGrid ();
			Debug.Log ("gird has initital items " + postionsNew.Count);
			arrangeGrids ();
			populateGrid ();
			Debug.Log ("number postions filled by the array of traps are  " + trapPostions.Count);
			Debug.Log ("postions filled by the array of ground are  " + groundPositions.Count);

		}
	}
	

	//alternate approuch to bulding random riles - this is grid based 
	//works create a gird based on size 
	void CreateGrid(){
		
		for (int i = 0; i <= x; i++) {
			for (int j = 0; j <= y; j++) {
				//only spawn this if ground is clear 
				Vector3 tmp = new Vector3((i), (j), 0);
					postionsNew.Add (tmp);

			}
	}
	}
	//fills random traps and then fils the rest with ground 
	//seprates the grid into random elements of traps and  fills the rest with ground 
	void arrangeGrids(){
	
		int cntr = 0;
		foreach (Vector3 v in postionsNew) {
	
			if (cntr <= maxTotalTraps) {
				
				int rndx = Random.Range (0, x - 1);
				int rndy = Random.Range (0, y - 1);

				Vector3 tmp = new Vector3 ((rndx), (rndy), 0);
				cntr++;
				if (tmp != v) {
					trapPostions.Add (tmp);
				}


			}

//			if (cntr > maxTotalTraps) {
//				
//				groundPositions.Add (v);
//
//			}
		}
	
		for (int i = trapPostions.Count - 1; i >= 0; i--) {
			if (postionsNew.Contains (trapPostions [i])) {
				postionsNew.Remove (trapPostions [i]);
				Debug.Log ("item " + trapPostions [i] + " was removes");

			} 
		
		}
	
	}


	void populateGrid(){
		foreach (Vector3 v in trapPostions) {
			spawnTrapAtPostion (v);
		}
		foreach (Vector3 v in postionsNew) {
			Instantiate (prefabTraps [4],v, Quaternion.identity);

		}
	}



	//aulternate approuch to spawning traps  //random and checks 
	void spawnTraps(){
		for (int i = 0; i <= maxTotalTraps; i++) {

			int xPos = Random.Range (0, 51); 
			int yPos = Random.Range (0, 51); 

			Vector3 tmpPostion = new Vector3 (xPos, yPos, 0);
			//postions.Add (tmpPostion);
			bool tmpcheck = checkArea (xPos, yPos, minxyDistance);
			Debug.Log (checkArea (xPos, yPos, minxyDistance));
			if (tmpcheck) {
				spawnTrapAtPostion (tmpPostion);
			} else {
				spawnTrapAtPostion (tmpPostion);

			}

		}
	
	}

	//check srrounding area 
	bool checkArea(float x, float y, float minDistance ){

		if (postions == null) {
			
			IsCloseToTrap = false;
			return false;
		} 

		IsCloseToTrap = false;

		for (int i = 0; i < postions.Count; i++) {
			if (x >= (Mathf.Abs (postions [i].x) - minDistance) && x <= (Mathf.Abs (postions [i].x) + minDistance)) {//|| Mathf.Abs (y) <= Mathf.Abs (i.y) + minDistance)
				//IsCloseToTrap = true;
				Debug.Log ("last X WAS LESS");
				Debug.Log ("last X in range True");

				IsCloseToTrap = true;
				postions.Remove (postions [i]);

			} else {
				IsCloseToTrap = false;
				postions.Add (postions [i]);

			
			}

			}

		return IsCloseToTrap;

	}

	//creates a random peostion 

	Vector3 CreatPostion (){

		int xPos = Random.Range (0, 50); 
		int yPos = Random.Range (0, 50); 

		return new Vector3 (xPos, yPos, 0);

	}

//spawn random traps 
	void spawnTrapRandom(Vector3 tmpPostion){
	
//		if(!IsCloseToTrap ){

//			Debug.Log ("reachedSpawningpoint");
		int tmp = Random.Range (0, 101);

			if (tmp >= 75) {
				Instantiate (prefabTraps [0], tmpPostion, Quaternion.identity);
				butn++;
				//spawn button - prefab 1 
			}
			if (tmp < 75 && tmp >= 50) {
				Instantiate (prefabTraps [1], tmpPostion, Quaternion.identity);
				pits++;
				//spawn pits  - prefab 2 
			}

			if (tmp < 50 && tmp >= 20) {
				//spawn spikes  - prefab 3
				Instantiate (prefabTraps [2],tmpPostion, Quaternion.identity);
				spiks++;

			}

			if (tmp < 20) {
				Instantiate (prefabTraps [3],tmpPostion, Quaternion.identity);
				snakes++;
				//spawn prefab four - snakes 
			}
	
	}


	void spawnTrapAtPostion(Vector3 pos){
	

			int tmp = Random.Range (0, 101);

			if (tmp >= 75) {
			Instantiate (prefabTraps [0], pos, Quaternion.identity);
				butn++;
				//spawn button - prefab 1 
			}
			if (tmp < 75 && tmp >= 50) {
			Instantiate (prefabTraps [1], pos, Quaternion.identity);
				pits++;
				//spawn pits  - prefab 2 

			}

			if (tmp < 50 && tmp >= 20) {
				//spawn spikes  - prefab 3
			Instantiate (prefabTraps [2],pos, Quaternion.identity);
				spiks++;

			}

			if (tmp < 20) {
			Instantiate (prefabTraps [3],pos, Quaternion.identity);
				snakes++;
				//spawn prefab four - snakes 

			}

		}


}

////old arrrangmen method 
/// 
//if (tmp != v) { //compares it to last element not efficant to use loop but.... for now for proof of concept ( newsted loop agh) 
//				if (!groundPositions.Contains (tmp)) {
//					trapPostions.Add (tmp);
//					cntr++;
//				} else {
//					continue;
//				}
//				//}
//			
//			}
//			else { //add whatever is remaining as a trap 
//				groundPositions.Add (v);
//			}
////			if (cntr <= maxFloorTiles) { //add checks< grid size

//		if(cntr <= maxFloorTiles){
//			postionsNew.Add (tmp);
//			cntr++;
//			//else skip an iteration
//		}
//		trapPostions
////
//
//
//void spawnFloor(){//this locates  traps for now - just checking somehting 
//	//spawns floor elements to max array size ( same range ) then add them to their own list and pop this one from the spawn list ( save original for traps )
//	//foreach (Vector3 v in postionsNew) {
//
//	for (int i = 0; i <= postionsNew.Count ; i++){
//		int rndx = Random.Range (31, 35);
//		int rndy = Random.Range (0, y);
//		Vector3 tmp = new Vector3((rndx), (rndy), 0);
//		//groundPositions.Add (tmp); works - just swapning traps and ground 
//		if (!trapPostions.Contains (tmp)) {
//			trapPostions.Add (tmp);
//		}
//		//postionsNew.Remove (tmp);
//
//	}//end of for loop 
//
//}
//
//void spawnFloorTile(){
//	foreach (Vector3 v in groundPositions) {
//		Instantiate (prefabTraps [4],v, Quaternion.identity);
//	}
//}
//
////create alternate one aand have it jump over it ---move grids / will have two this way one for objects only spawn when element is not taken - else add it to the array 
//
//void spawnTrapsandWalls(){
//	int cntr = 0;
//	foreach (Vector3 pos in  trapPostions) {
//		if (cntr <= maxTotalTraps) { //add checks< grid size
//			//
//			if (!groundPositions.Contains (pos) ) {
//				spawnItemRandom (pos);
//
//			}
//
//		}
//	}
//}

//////			//spawnItemRandom (tmpPostion);

//			//spawnItemRandom (tmpPostion);
//			if (!Physics.CheckSphere (tmpPostion, minxyDistance)) {
//				spawnItemRandom (tmpPostion);
//				Gizmos.DrawSphere (tmpPostion, minxyDistance);
//
//
//			
//			} else {
//				postions.Remove(tmpPostion);
//				i--;
//			}



//old spawn traps method 
//IsCloseToTrap = checkArea (tmpPostion.x, tmpPostion.y, 0);
//			if (IsCloseToTrap) {
//				Debug.Log ("TOO CLOSE TO OTHER TRAP CHANING POSTION");
//
//				 tmpPostion =  CreatPostion ();
//				 postions.Add (tmpPostion);
//				if (checkArea (tmpPostion.x, tmpPostion.y, 0)== false) {
//					IsCloseToTrap = false;
//					spawnItemRandom (tmpPostion);
//
//				} else {
//					IsCloseToTrap = true;
//				}
//
//				//unIsCloseToTrap = false;
//				//IsCloseToTrap = checkArea (tmpPostion.x, tmpPostion.y, 2);
//
//
//			
//
//		
//			}
