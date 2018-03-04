using System.Collections;
using System.Collections.Generic;
using Caterative.Brick.Balls;
using UnityEngine;

public class GameManager : Singleton<GameManager> {
	PlayerAim aim;

	void Awake() {
		aim = FindObjectOfType<PlayerAim>();
	}

	void OnEnable() {
		BallDestroyer.Instance.OnBallDestroy += RestartTheBall;
	}

	void OnDisable() {
		BallDestroyer.Instance.OnBallDestroy -= RestartTheBall;
	}

	public void ReadyTheBall() {
		aim.ReloadBall(BallManager.Instance.GetAvailableBall());
	}

	public void RestartTheBall(Ball ball) {
        GameManager.Instance.ReadyTheBall();
	}
}
