﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour {
	private Ball ballToLaunch;
	public LineRenderer targetLine;
	private float launchDirection;
	public float launchSpeed;
	private Vector2 startLaunchLocation;
	public GameObject ballsPool;
	// Use this for initialization
	void Awake () {
		targetLine.positionCount = 2;
		ReloadBall();
	}
	
	// Update is called once per frame
	void Update () {
		UpdateLaunchDirection();
	}
	public void UpdateLaunchDirection() {
		launchDirection = 90 + ((transform.position.x / 2) * -45);
		Vector2 originalBallLocation = new Vector2(
			transform.position.x * 1.25f,
			transform.position.y + 0.5f
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
		startLaunchLocation = originalBallLocation;
	}
	public void Shoot() {
		if (ballToLaunch != null) {
			ballToLaunch.GetComponentInChildren<TrailRenderer>().enabled = true;
			ballToLaunch.transform.position  = startLaunchLocation;
			ballToLaunch.LaunchTowardsAngle(launchSpeed,launchDirection);
			//ReloadTime(1f);
			ballToLaunch = null;
		}
	}
	public void ReloadBall() {
		if (ballsPool.transform.childCount > 0) {
			GameObject currentBall = ballsPool.transform.GetChild(0).gameObject;
			ballToLaunch = currentBall.GetComponent<Ball> ();
			currentBall.transform.SetParent(null);
		} else {
			ballToLaunch = null;
			targetLine.enabled = false;
		}
	}
	IEnumerator ReloadTime(float inputTime) {
		//ReloadBall();
		yield return new WaitForSeconds(inputTime);
	}
}
