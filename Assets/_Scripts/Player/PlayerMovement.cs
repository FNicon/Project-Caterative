using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	public float playerMaxY;
	public float playerMinY;
	public float playerSpeed;
	private Rigidbody2D playerBody;
	private Transform cameraTransform;

	void Awake()
	{
		playerBody = gameObject.GetComponent<Rigidbody2D>();
		cameraTransform = Camera.main.transform;
	}

	public void Move(Vector2 input)
	{
		Vector2 deltaVelocity = new Vector2(input.x * playerSpeed, input.y * playerSpeed);
		//Vector2 destination = (Vector2)transform.position + deltaVelocity;
		//playerBody.MovePosition(ConstraintMovement(destination));
		playerBody.velocity = deltaVelocity;
	}

	public void MoveAndroid(Vector2 input)
	{
		playerBody.MovePosition(ConstraintMovement(input));
	}

	public void ConstraintPlayerMovement()
	{
		float MaxY = playerMaxY + cameraTransform.position.y;
		float MinY = playerMinY + cameraTransform.position.y;
		transform.position = new Vector2(transform.position.x, Mathf.Clamp(transform.position.y, MinY, MaxY));
	}

	public Vector2 ConstraintMovement(Vector2 input)
	{
		float MaxY = playerMaxY + cameraTransform.position.y;
		float MinY = playerMinY + cameraTransform.position.y;
		return new Vector2(input.x, Mathf.Clamp(input.y, MinY, MaxY));
	}
}
