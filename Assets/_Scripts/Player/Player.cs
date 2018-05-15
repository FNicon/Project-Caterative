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
	public bool isWin;
	private void Awake() {
		playerAim = gameObject.GetComponent<PlayerAim>();
		playerController = gameObject.GetComponent<PlayerController>();
		playerControllerAndroid = gameObject.GetComponent<PlayerControllerAndroid>();
		playerEffectStatus = gameObject.GetComponent<PlayerEffectStatus>();
		playerLife = gameObject.GetComponent<PlayerLife>();
		playerMovement = gameObject.GetComponent<PlayerMovement>();
	}
	public bool IsAbleToMove()
	{
		return (playerLife.IsAlive() && !playerEffectStatus.IsCurrentlyStun() && !isWin);
	}
	void Update()
	{
		if (IsAbleToMove())
		{
			#if UNITY_EDITOR || UNITY_STANDALONE_WIN
			if (playerController.IsInputFire())
			{
				playerAim.Shoot();
			}
			#endif
			#if UNITY_ANDROID && !UNITY_EDITOR
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
			#if UNITY_EDITOR || UNITY_STANDALONE_WIN
			playerMovement.Move(playerController.ReadInput());
			#endif
			#if UNITY_ANDROID && !UNITY_EDITOR
			playerMovement.MoveAndroid(playerControllerAndroid.ReadInput());
			#endif
		}
	}
}

