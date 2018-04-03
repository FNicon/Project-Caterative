using System.Collections;
using System.Collections.Generic;
using Caterative.Brick.Balls;
using Caterative.Brick.TheShieldBoss;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    PlayerAim aim;
    PlayerLife life;
    //ShieldPupil pupil;
    Ball ball;

    void Awake()
    {
        aim = FindObjectOfType<PlayerAim>();
        life = FindObjectOfType<PlayerLife>();
        //pupil = FindObjectOfType<ShieldPupil>();
        ball = FindObjectOfType<Ball>();
    }

    void OnEnable()
    {
        BallDestroyer.OnBallDestroy += OnBallDestroy;
    }

    void OnApplicationQuit()
    {
        BallDestroyer.OnBallDestroy -= OnBallDestroy;
    }

    void Update()
    {
        if (ball.active)
        {
            //pupil.SetTarget(ball.transform);
        } else
        {
            //pupil.SetTarget(aim.transform);
        }
    }

    public void ReadyTheBall()
    {
        aim.ReloadBall(BallManager.Instance.GetAvailableBall());
    }

    public void OnBallDestroy(Ball ball)
    {
        if (BallManager.Instance.CountActiveBall() <= 0)
        {
            life.GetDamage();
        }
        GameManager.Instance.ReadyTheBall();
    }

    public Ball GetBall()
    {
        return (ball);
    }

    public PlayerAim GetAim()
    {
        return (aim);
    }
}
