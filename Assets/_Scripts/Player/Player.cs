using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	private Rigidbody2D playerBody;
	public float playerSpeed;
	public PlayerController playerController;
	public Ball ballToLaunch;
	public LineRenderer targetLine;
	public float launchDirection;
	public float launchSpeed;

	// Use this for initialization
	void Awake() {
		playerBody = gameObject.GetComponent<Rigidbody2D>();
		targetLine.positionCount = 2;
	}
	
	// Update is called once per frame
	void Update () {
		MoveHorizontal(playerController.InputHorizontal());
		launchDirection = 90 + ((transform.position.x / 2) * -45);
			Vector2 originalBallLocation = new Vector2(
				transform.position.x * 1.25f,
				transform.position.y + 0.2f
			);
			targetLine.SetPosition(0, originalBallLocation);
			Vector2 launchVector = VectorRotation.RotateVector(Vector2.right, launchDirection);
			int layerMask = LayerMask.GetMask("Default");
			RaycastHit2D hit = Physics2D.Raycast(transform.position, launchVector, 100, layerMask);
			if (hit.collider != null) {
				targetLine.SetPosition(1, hit.point);
			} else {
				targetLine.SetPosition(1, launchVector * 10);
			}
		if (playerController.IsInputFire()) {
			ballToLaunch.transform.position = originalBallLocation;
			ballToLaunch.LaunchTowardsAngle(launchSpeed,launchDirection);
		}
	}
	void MoveHorizontal(float inputHorizontal) {
		playerBody.velocity = new Vector2(inputHorizontal*playerSpeed,0);
	}
	void UpdateLaunchDirection() {
		
	}
}
