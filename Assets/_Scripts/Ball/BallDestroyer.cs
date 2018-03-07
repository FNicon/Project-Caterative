using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Caterative.Brick.Balls {
	public class BallDestroyer : Singleton<BallDestroyer> {
		public delegate void BallDestroyEvent(Ball whichBall);
		public static event BallDestroyEvent OnBallDestroy;

		void OnTriggerEnter2D(Collider2D other) {
			Ball ball = other.GetComponent<Ball>();
			if (ball != null) {
				ball.Deactivate();
				if (OnBallDestroy != null) {
					OnBallDestroy(ball);
				}
			}
		}
	}
}