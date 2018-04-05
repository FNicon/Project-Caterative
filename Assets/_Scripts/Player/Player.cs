using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	private PlayerAim playerAim;
	private PlayerController playerController;
	private PlayerControllerAndroid playerControllerAndroid;
	private PlayerEffectStatus playerEffectStatus;
	private PlayerLife playerLife;
	private PlayerMovement playerMovement;
	private void Awake() {
		playerAim = gameObject.GetComponent<PlayerAim>();
		playerController = gameObject.GetComponent<PlayerController>();
		playerControllerAndroid = gameObject.GetComponent<PlayerControllerAndroid>();
		playerEffectStatus = gameObject.GetComponent<PlayerEffectStatus>();
		playerLife = gameObject.GetComponent<PlayerLife>();
		playerMovement = gameObject.GetComponent<PlayerMovement>();
	}
	private bool IsAbleToMove()
	{
		return (playerLife.IsAlive() && !playerEffectStatus.IsCurrentlyStun());
	}
	void Update()
	{
		if (IsAbleToMove())
		{
			#if UNITY_EDITOR
				if (playerController.IsInputFire())
				{
					playerAim.Shoot();
				}
			#elif UNITY_ANDROID
				if(playerControllerAndroid.IsInputFire())
				{
					playerAim.Shoot();
				}
			#endif
		}
	}

	void FixedUpdate()
	{
		playerMovement.ConstraintPlayerMovement();
		if (IsAbleToMove())
		{
			#if UNITY_EDITOR
				playerMovement.Move(playerController.ReadInput());
			#elif UNITY_ANDROID
				playerMovement.MoveAndroid(playerControllerAndroid.ReadInput());
			#endif
		}
	}
}

