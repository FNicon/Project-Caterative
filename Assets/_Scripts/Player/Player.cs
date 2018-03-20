using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	private Rigidbody2D playerBody;
	public float playerSpeed;
	public PlayerController playerController;
	//public PlayerControllerAndroid playerControllerAndroid;
	public PlayerAim playerAim;
	public PlayerLife playerLife;

	// Use this for initialization
	void Awake() {
		playerBody = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		#if UNITY_EDITOR
			if (playerLife.IsAlive()) {
				Move(playerController.ReadInput());
	            if (playerController.IsInputFire()) {
					playerAim.Shoot();
				}
	        }
		#elif UNITY_ANDROID
		if (playerLife.IsAlive()) {
			MoveHorizontal(playerControllerAndroid.InputHorizontal());
		}
		#endif
    }

void Move(Vector2 input) {
		Vector2 deltaVelocity = new Vector2 (input.x * playerSpeed, input.y * playerSpeed);
		playerBody.velocity = deltaVelocity;
    }
}

