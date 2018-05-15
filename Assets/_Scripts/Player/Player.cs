using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	private PlayerAim playerAim;
	private PlayerController playerController;
	//private PlayerControllerAndroid playerControllerAndroid;
	private PlayerEffectStatus playerEffectStatus;
	private PlayerLife playerLife;
	private PlayerMovement playerMovement;
	public bool isWin;
	private void Awake() {
		playerAim = gameObject.GetComponent<PlayerAim>();
		playerController = gameObject.GetComponent<PlayerController>();
		//playerControllerAndroid = gameObject.GetComponent<PlayerControllerAndroid>();
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
				if (playerController.IsInputFire())
				{
					playerAim.Shoot();
				}
				/*if(playerControllerAndroid.IsInputFire())
				{
					playerAim.Shoot();
				}*/
		}
	}

	void FixedUpdate()
	{
		playerMovement.ConstraintPlayerMovement();
		if (IsAbleToMove())
		{
			playerMovement.Move(playerController.ReadInput());
			//playerMovement.MoveAndroid(playerControllerAndroid.ReadInput());
		}
	}
}

