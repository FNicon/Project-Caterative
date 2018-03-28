using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Caterative.Brick.Balls;

public class Warp : MonoBehaviour, ICollidable {
	public GameObject destination;

	void ICollidable.OnCollideWithBall(Ball ball) {
		TrailRenderer trail = ball.GetComponentInChildren<TrailRenderer> ();
		if (ball.tag == "Ball") {
			ball.transform.position = destination.transform.position;
			ball.tag = "Warping";
			//trail.enabled = false;
		} else {
			StartCoroutine(SetTag(1,ball,trail));
		}
	}

	IEnumerator SetTag(int n, Ball target, TrailRenderer trail) {
		yield return new WaitForSeconds (n);
		target.tag = "Ball";
		//trail.enabled = true;
	}
}