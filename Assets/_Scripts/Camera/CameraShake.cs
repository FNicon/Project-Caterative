using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {
	private float countTime;
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
		float xForce = magnitude;
		StartCoroutine(shaking(xForce));
	}
	IEnumerator shaking(float xForce) {
		transform.position = Vector3.MoveTowards(
			transform.position, 
			new Vector3(xForce,transform.position.y,transform.position.z),
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
			transform.position = new Vector3(0,transform.position.y,transform.position.z);
			countTime = 0;
			yield return new WaitForSeconds(0.1f);
		}
		
	}
}
