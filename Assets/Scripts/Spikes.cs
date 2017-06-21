using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : Traps {
	[SerializeField]
	float timer = 6; // timer till spikes go up or down - have this in update 
	public float countdown = 6; // timer till spikes go up or down - have this in update 
	[SerializeField]
	bool isSpikep;
	Color baseColor;
	Color clr;
	SpriteRenderer rnd;
	// Use this for initialization
	void Start () {
		
		rnd = gameObject.GetComponent<SpriteRenderer> ();
		baseColor = rnd.color;
	}
	
	// Update is called once per frame
	void Update () {
		if (timer >=0) {
			timer -= Time.deltaTime;
			if (timer < countdown && timer >= (countdown/2)  ) {
				Debug.Log ("timer true ( spikes up ");
				isSpikep = true;
				rnd.color = Color.grey;

			}if (timer < (countdown/2)) {
				isSpikep = false;
				rnd.color = baseColor;
				Debug.Log ("spikes is false ");

			}

		} 
		else {
			timer = countdown;
			Debug.Log ("timer Done - resetting" );

		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			if (isSpikep == true) {
				Debug.Log ("player is dead");
			}
		}
	}
	//if the player lags on it this is called each frame 
	void OnTriggerStay(Collider other){
		
		if (other.tag == "Player") {
			if (isSpikep == true) {
			Debug.Log ("player is dead");	}
		}
	}
}
