using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : Traps {
	[SerializeField]
	float timer = 6; // timer till spikes go up or down - have this in update 
	public float countdown = 6; // timer till spikes go up or down - have this in update 
	[SerializeField]
	bool isSpikep;
	// Use this for initialization
	void Start () {
		//base.spawnObject ();
		//Debug.Log("spikenoot noot");

	}
	
	// Update is called once per frame
	void Update () {
		if (timer >=0) {
			timer -= Time.deltaTime;
			if (timer < 6 && timer >= 3 ) {
				Debug.Log ("timer true ( spikes up ");
				isSpikep = true;
			}if (timer < 3) {
				isSpikep = false;

				Debug.Log ("timer Done - resetting - spikes is false ");

			}

		} 
		else {
			timer = countdown;
			Debug.Log ("timer Done - resetting - spikes is false ");
			isSpikep = false;
		}
	}
}
