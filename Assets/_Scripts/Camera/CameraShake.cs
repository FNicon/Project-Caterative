﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {
	private float countTime;
	private Vector3 startShakePosition;
	public float shakeTime;
	public float magnitude;
	public float timeMultiplier;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}
	public void Shake() {
		startShakePosition = transform.position;
		float xForce = magnitude;
		StartCoroutine(shaking(xForce));
	}
	IEnumerator shaking(float xForce) {
		transform.position = Vector3.MoveTowards(
			transform.position, 
			new Vector3(startShakePosition.x + xForce,startShakePosition.y, transform.position.z),
			Time.deltaTime * timeMultiplier
		);
		countTime = countTime + 0.1f;
		if (countTime < shakeTime) {
			float currentSign = xForce/Mathf.Abs(xForce);
			float newForce = Mathf.Abs(xForce) - 0.1f;
			xForce = newForce * currentSign;
			yield return new WaitForSeconds(0.1f);
			StartCoroutine(shaking(-xForce));
		} else {
			transform.position = Vector3.MoveTowards(
				transform.position,startShakePosition,Time.deltaTime * timeMultiplier
			);
			countTime = 0;
			yield return new WaitForSeconds(0.1f);
		}
		
	}
}
