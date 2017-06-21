using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//type trap one 
public class Pits : Traps {

	// Use this for initialization
	private int Counter; // number of times the player can hit it without dying 
	SpriteRenderer spriteRend;
	Color baseColor, decreasedAlphaColor;

	void Start () {
		base.anim = GetComponent<Animator> ();
		//base.spawnObject ();
		spriteRend = gameObject.GetComponent<SpriteRenderer> ();
		baseColor = spriteRend.color;
		baseColor.a = 255;
		Debug.Log ("It has begun");
		//call the check from parent class to spawn them 
	}

	// Update is called once per frame
	void Update () {
		
	}


	void OnTriggerEnter(Collider coll) {

		if (coll.tag == " Player") {
			affectOfPit ();
			if (Counter <= 0) {
				//invoke method to kill player and repeat the game - from other menu
			}
		}
	}


	//decrease the counter - if its more than one change the alpha 
	void affectOfPit(){
		
		this.Counter--;
		if (Counter >= 1) { //decrease alpha by 100 pet hit 
			int tmpalpha = 100;
			Color tmp = baseColor;
			tmp.a -= tmpalpha;
			spriteRend.color = tmp;
			Debug.Log ("The pit has happened");
		} 
	}
}
