using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traps : MonoBehaviour {


	protected bool isActive = false;
	float sphereRadius = 20;
	public Animator anim;
	protected int maxOfThisTrap;
	protected int minOfThisTrap;
	protected AudioClip sfx;
	public AudioSource sfxSrc;
	public Vector3 lastTemp; // last saved temp postion 
	// Use this for initialization
	void Start () {
		sfxSrc = gameObject.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void checkIfLegalLocation(){
		// if it is spawened in an illegal zone respawn it 
		//as long as the object is < than the min of each one
	
	}

	public void respawnObject(){
		//as long as the object is < than the min of each one

	}

	public virtual void spawninAnotherLocation(){
		//instaniate another one - dofff in each subcalss 
	}

	//moving object 
//	public virtual void spawnObject(){
//		Debug.Log ("called from child");
//		//check if legal 
//		int rndX = Random.Range (0, 41);
//		int rndY = Random.Range (0, 31);
//
//		Vector3 tmp = new Vector3( rndX, rndY, 0); 
//		if (Physics.CheckSphere (tmp , sphereRadius)) {
//			
//			int X = Random.Range (0, 41);
//			int Y = Random.Range (0, 31);
//			Vector3 tmp2= new Vector3( X, Y, 0); 
//			gameObject.transform.position = tmp2;
//
//			
//		} else {
//			gameObject.transform.position = tmp;
//	
//		}
//	}

}
