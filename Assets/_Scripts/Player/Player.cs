using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public PlayerController playerController;
	public PlayerControllerAndroid playerControllerAndroid;
	public PlayerAim playerAim;
	public PlayerLife playerLife;
	public PlayerEffectStatus playerStatus;
	public PlayerMovement playerMovement;
	private bool IsAbleToMove()
	{
		return (playerLife.IsAlive() && !playerStatus.IsCurrentlyStun());
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

