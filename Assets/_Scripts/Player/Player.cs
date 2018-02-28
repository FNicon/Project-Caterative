using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	private Rigidbody2D playerBody;
	public float playerSpeed;
	public PlayerController playerController;
	public PlayerAim playerAim;

	// Use this for initialization
	void Awake() {
		playerBody = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		MoveHorizontal(playerController.InputHorizontal());
		if (playerController.IsInputFire()) {
			playerAim.Shoot();
		}
	}
	void MoveHorizontal(float inputHorizontal) {
		playerBody.velocity = new Vector2(inputHorizontal*playerSpeed,0);
	}
}
