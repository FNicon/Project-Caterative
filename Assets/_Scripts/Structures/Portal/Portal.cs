using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {
	public Transform nextPortal;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private void OnTriggerEnter2D(Collider2D other) {
		BallPortal ballEnter = other.GetComponent<BallPortal>();
		if (other.CompareTag("Ball") && ballEnter.portalFrom == null) {
			ballEnter.portalFrom = gameObject;
			other.transform.position = nextPortal.position;
		}
	}
	private void OnTriggerExit2D(Collider2D other) {
		BallPortal ballExit = other.GetComponent<BallPortal>();
		if (other.CompareTag("Ball") && ballExit.portalFrom != gameObject) {
			ballExit.portalFrom = null;
		}
	}
}
