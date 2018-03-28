using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	private Rigidbody2D playerBody;
	private Transform cameraTransform;
	public float playerSpeed;
	public PlayerController playerController;
	//public PlayerControllerAndroid playerControllerAndroid;
	public PlayerAim playerAim;
	public PlayerLife playerLife;
	public GameObject currentCamera;
	public float playerMaxY;
	public float playerMinY;

	void Awake()
	{
		playerBody = gameObject.GetComponent<Rigidbody2D>();
		cameraTransform = currentCamera.GetComponent<Transform> ();
	}
	
	void Update ()
	{
		#if UNITY_EDITOR
			if (playerLife.IsAlive())
			{
			Move(playerController.ReadInput());
	            if (playerController.IsInputFire())
				{
					playerAim.Shoot();
				}
			ConstraintPlayerMovement();
	        }
		#elif UNITY_ANDROID
		if (playerLife.IsAlive())
		{
			Move(playerControllerAndroid.ReadInput());
		}
		#endif
    }

	void Move(Vector2 input)
	{
		Vector2 deltaVelocity = new Vector2 (input.x * playerSpeed, input.y * playerSpeed);
		playerBody.velocity = deltaVelocity;
    }

	void ConstraintPlayerMovement()
	{
		float MaxY = playerMaxY + cameraTransform.position.y;
		float MinY = playerMinY + cameraTransform.position.y;
		/*Debug.Log ("Player pos = " + transform.position.y);
		Debug.Log ("Max Y = " + MaxY);
		Debug.Log ("Min Y = " + MinY);
		Debug.Log ("Camera pos " + cameraTransform.position.y);*/
		transform.position = new Vector2 (transform.position.x, Mathf.Clamp (transform.position.y, MinY, MaxY));
	}
}

