using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//type trap two 

public class Snakes : Traps {
	//trap manager randomly spawn types of traps 
	Player plr;
	public float rad;
	public LayerMask lyr;
	public bool PoisnedPlayer = false;
	public bool isPlayerInRange = false;
	public bool antedoteSpawnd = false;
	Vector3 iniitalPostion; 
	Vector3 pA, pB;
	public int xTileCount =1;
	public int yTileCount =1;

	public int x;

	public float snakeSpeed = 2 ;
	public GameObject snakeNestPrefab;
	public GameObject antedotePrefab;//find object within floor items and span it there if player is bitten
	public GameObject projectilePrefab;
	public  float bulletSpeed;
	//get player refrence 
	//add  potion object 
	// Use this for initialization
	void Start () {
		//base.spawnObject ();
		//rad = 3;
		plr = FindObjectOfType<Player>();
		iniitalPostion = gameObject.GetComponent<Transform>().position;
		Instantiate (snakeNestPrefab, iniitalPostion, Quaternion.identity);
		x = Random.Range (0, 11);


		pA = iniitalPostion;
		pB = iniitalPostion;

		if (x > 5) {
			xTileCount = Random.Range (1, 4);
			yTileCount = 0;
			pA.x = iniitalPostion.x + xTileCount;//this is done with x but can change it ot y 
			pB.x = iniitalPostion.x - xTileCount; 
		
		} if (x <= 4) {
			yTileCount = Random.Range (1, 4);
			xTileCount = 0;
			pA.z = iniitalPostion.z + yTileCount;//this is done with x but can change it ot y 
			pB.z = iniitalPostion.z - yTileCount;

		}

//		pA.x = iniitalPostion.x + xTileCount;//this is done with x but can change it ot y 
//		pB.x = iniitalPostion.x - xTileCount; // need to add edge case to stop it from going itnp walls 

	;
	}
	
	// Update is called once per frame
	void Update () {

		MovefromAtoB ();
		poisonPlayer ();
	}

	//compare ditance to player - if close poison player 
	public void checkDistance(){
	}

	//snakes patrol 
	public void MovefromAtoB(){
		

			transform.position = Vector3.Lerp (pA, pB, Mathf.PingPong (Time.time * snakeSpeed, 1.0f));
		
	}

	//spawnAntedote and poison player
	void poisonPlayer(){
		if (!isPlayerInRange) {
			//change this into an enum to control movment after
			if (Physics.CheckSphere (transform.position, rad, lyr)) {
				snakeSpeed = 0;
				GameObject obj = Instantiate (projectilePrefab, transform.position, Quaternion.identity);
				Rigidbody rg = obj.GetComponent<Rigidbody> ();
				gameObject.transform.LookAt (plr.transform);
				rg.AddForce (transform.forward * bulletSpeed); 
				//poison player 
				//span antedote
				//once player is cured of poisn change range to false again 
				Debug.Log ("spaning antedote");
				isPlayerInRange = true;
			}
		}

	}

	void spawnAntedote(){
	
	}

	//
	void resetSnakeRange(){
		isPlayerInRange = false;
		//
	}
	//testing trigger
	void OnTriggerEnter(Collider other) {
		Debug.LogAssertion ("collided with snake");
}
}
