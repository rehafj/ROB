using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public float speed;
	private Rigidbody rgd; 
	private Vector3 movments; //for player drection
	private Vector3 vel; //movment velocity
	void Start(){

		rgd = gameObject.GetComponent<Rigidbody>();

	}

	void Update(){

		movments = new Vector3 (Input.GetAxisRaw ("Horizontal"), 0f, Input.GetAxisRaw ("Vertical"));
		vel = movments * speed;

	}
	//for physics movments --- 
	void  FixedUpdate(){
		
		rgd.velocity = vel;
	}
}
