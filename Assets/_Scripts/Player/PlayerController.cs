using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
	}
	public Vector2 ReadInput() {
		Vector2 movement;
		movement = new Vector2 (Input.GetAxis("Horizontal") , Input.GetAxis("Vertical"));
		return movement;
	}

	public bool IsInputFire() {
		return (Input.GetAxis("Jump") != 0);
	}
}
