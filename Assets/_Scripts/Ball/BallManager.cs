using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Caterative.Brick.Balls
{
    public class BallManager : Singleton<BallManager>
    {
        public delegate void BallEvent(Ball whichBall);
        public event BallEvent OnBallCollide;
        public event BallEvent OnBallTrigger;
        List<Ball> balls;

        void Awake() {
            balls = new List<Ball>((Ball[])Resources.FindObjectsOfTypeAll(typeof(Ball)));
            foreach (var ball in balls) {
            ball.Deactivate();
            }
        }

        public Ball GetAvailableBall() {
            Ball availableBall = null;
            int i = 0;
            while (availableBall == null && i < balls.Count) {
                if (balls[i].active == false) {
                    availableBall = balls[i];
                }
                i++;
            }
            return availableBall;
        }

        public int CountActiveBall()
        {
            int count = 0;
            foreach (var ball in balls)
            {
                if (ball.active)
                {
                    count++;
                }
            }
            return count;
        }

        internal void InvokeOnBallCollide(Ball ball)
        {
            if (OnBallCollide != null)
            {
                OnBallCollide(ball);
            }
        }

        internal void InvokeOnBallTrigger(Ball ball)
        {
            if (OnBallTrigger != null)
            {
                OnBallTrigger(ball);
            }
        }
    }
}