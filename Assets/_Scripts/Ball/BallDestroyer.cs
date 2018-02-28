using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDestroyer : MonoBehaviour {
	public Transform ballPools;
	public PlayerAim aim;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag("Ball")) {
			RelocateBall(other);
			aim.ReloadBall();
		}
	}
	void RelocateBall(Collider2D ball) {
		ball.transform.SetParent(ballPools);
		ball.GetComponentInChildren<TrailRenderer>().enabled = false;
		ball.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
		ball.transform.position = ball.transform.parent.position;
	}
}
