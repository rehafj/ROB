using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTraps : Traps {
	
	public enum buttonTraps {

		alarmTrap, dmgTrap, DudTrap
	}
	public buttonTraps typeOfTrap;
	// Use this for initialization
	void Start () {
		
		setButtonTrap ();
		//base.spawnObject ();

	//	Debug.Log ("trap was " + typeOfTrap);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void setButtonTrap(){

		int tmp = Random.Range (0, 11);
		if (tmp >= 6) {
			typeOfTrap = buttonTraps.dmgTrap;
			Debug.Log ("arrow trap Noot Noot");
			//mark this as trap one 
		}
		if (tmp <6 || tmp >=20) {
			//mark this as trap two 
			typeOfTrap = buttonTraps.DudTrap;
			Debug.Log ("Dud noot noot");


		}
		if (tmp <20) {
			typeOfTrap = buttonTraps.alarmTrap;
			Debug.Log ("timer noot noot");
			//mark this as trap three 

		}
	}
}
