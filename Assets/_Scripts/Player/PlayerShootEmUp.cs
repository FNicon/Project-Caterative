using System.Collections;
using System.Collections.Generic;
using Caterative.Brick.Balls;
using UnityEngine;

public class PlayerShootEmUp : MonoBehaviour {
	private Ball ballToLaunch;
	public float launchSpeed;
	public float cooldownTime;
	private float cooldownCountDown;
	private bool isStillReload = false;
	public PlayerAimViewer playerAimViewer;
	public GameObject createdBall;
	private void Awake() {
		GameObject newBall = Instantiate(createdBall, new Vector2(
				transform.position.x - 7, transform.position.y), 
				transform.rotation);
		BallManager.Instance.AddBall(newBall);
		ReloadBall(newBall.GetComponent<Ball>());
	}
	void Update()
	{
		if (ballToLaunch != null)
		{
			playerAimViewer.targetLine.positionCount = 2;
			Shoot();
		} else
		{
			//targetLine.positionCount = 0;
		}
		playerAimViewer.UpdateLaunchDirection();
	}

	public void Shoot()
	{
		if (ballToLaunch != null)
		{
			ballToLaunch.transform.position = playerAimViewer.startLaunchLocation;
			ballToLaunch.LaunchTowardsAngle(launchSpeed, playerAimViewer.launchDirection);
			ballToLaunch = null;
			//Debug.Log(BallManager.Instance.CountActiveBall());
			if (!isStillReload)
			{
				isStillReload = true;
				cooldownCountDown = 0;
				StartCoroutine(Cooldown());
			}
		}
	}
	public void RestartCoolDown() {
		StopAllCoroutines();
		cooldownCountDown = 0;
		isStillReload = false;
	}
	IEnumerator Cooldown() {
		yield return new WaitForSeconds(0.1f);
		cooldownCountDown = cooldownCountDown + 0.1f;
		playerAimViewer.UpdateCoolDown(cooldownCountDown, cooldownTime);
		if (cooldownCountDown >= cooldownTime)
		{
			isStillReload = false;
			GameObject newBall = Instantiate(createdBall, new Vector2(
				transform.position.x - 7, transform.position.y), 
				transform.rotation);
			BallManager.Instance.AddBall(newBall);
			ReloadBall(newBall.GetComponent<Ball>());
		} else {
			StartCoroutine(Cooldown());
		}
	}

	public void ReloadBall(Ball ball)
	{
		ballToLaunch = ball;
	}
}
