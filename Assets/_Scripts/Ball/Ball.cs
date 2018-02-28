using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
	public float maxSpeed;
	public float minSpeed;
	public int speedIterator;
	private Rigidbody2D ballBody;
	// Use this for initialization
	void Start () {
		ballBody = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if ((Mathf.Abs(ballBody.velocity.x) > maxSpeed) || (Mathf.Abs(ballBody.velocity.y) > maxSpeed)) {
			ballBody.velocity = maxSpeed * (ballBody.velocity.normalized);
			speedIterator = 0;
		} else if ((ballBody.velocity.x < minSpeed) || (ballBody.velocity.y < minSpeed)) {
			ballBody.velocity = (minSpeed + speedIterator) * (ballBody.velocity.normalized);
			speedIterator = speedIterator + 1;
		} else {
			ballBody.velocity = new Vector2 (ballBody.velocity.x,ballBody.velocity.y);
		}
		if (speedIterator > 10) {
			speedIterator = 0;
		}
	}

	public void LaunchTowardsAngle(float initialSpeed, float direction) {
		Vector2 directionVector = VectorRotation.RotateVector(Vector2.right,direction);
		Vector2 launchVelocity = (directionVector * initialSpeed);
		ballBody.velocity = launchVelocity;
	}
}
