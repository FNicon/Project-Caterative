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
	public float InputHorizontal() {
		return (Input.GetAxis ("Horizontal"));
	}

	public bool IsInputFire() {
		return (Input.GetAxis("Jump") != 0);
	}
}
