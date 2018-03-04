using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Caterative.Brick.Balls
{
    public class BallManager : Singleton<BallManager>
    {
        List<Ball> balls;
        public delegate void BallCollideEvent(Ball whichBall, ICollidable whichCollidable);
        public event BallCollideEvent OnBallCollide;

        void Awake()
        {
            balls = new List<Ball>((Ball[])Resources.FindObjectsOfTypeAll(typeof(Ball)));
            foreach (var ball in balls)
            {
                ball.Deactivate();
            }
        }

        public Ball GetAvailableBall()
        {
            Ball availableBall = null;
            int i = 0;
            while (availableBall == null && i < balls.Count)
            {
                if (balls[i].active == false)
                {
                    availableBall = balls[i];
                }
                i++;
            }
            return availableBall;
        }

        internal void InvokeOnBallCollide(Ball ball, ICollidable collidable)
        {
            if (OnBallCollide != null)
            {
                OnBallCollide(ball, collidable);
            }
        }
    }
}