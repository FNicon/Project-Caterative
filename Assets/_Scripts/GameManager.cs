using System.Collections;
using System.Collections.Generic;
using Caterative.Brick.Balls;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    PlayerAim aim;
    PlayerLife life;

    void Awake()
    {
        aim = FindObjectOfType<PlayerAim>();
        life = FindObjectOfType<PlayerLife>();
    }

    void OnEnable()
    {
        BallDestroyer.Instance.OnBallDestroy += OnBallDestroy;
    }

    void OnDisable()
    {
        BallDestroyer.Instance.OnBallDestroy -= OnBallDestroy;
    }

    public void ReadyTheBall()
    {
        aim.ReloadBall(BallManager.Instance.GetAvailableBall());
    }

    public void OnBallDestroy(Ball ball)
    {
        life.GetDamage();
        GameManager.Instance.ReadyTheBall();
    }
}
