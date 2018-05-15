using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Caterative.Brick.Balls
{
    public class BallManager : Singleton<BallManager>
    {
        public delegate void BallEvent(Ball whichBall);
        public event BallEvent OnBallCollide;
        public event BallEvent OnBallTrigger;
        List<GameObject> balls;

        void Awake()
        {
            //balls = new List<Ball>((Ball[])).FindObjectsOfTypeAll(typeof(Ball));
            balls = new List<GameObject>(GameObject.FindGameObjectsWithTag("Ball"));
            foreach (var ball in balls)
            {
                ball.GetComponent<Ball>().Deactivate();
            }
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        void OnApplicationQuit() {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }

        private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
        {
            balls = new List<GameObject>(GameObject.FindGameObjectsWithTag("Ball"));
            foreach (var ball in balls)
            {
                ball.GetComponent<Ball>().Deactivate();
            }   
        }

        public void AddBall(GameObject newBall) {
            balls.Add(newBall);
        }

        public Ball GetAvailableBall()
        {
            Ball availableBall = null;
            int i = 0;
            while (availableBall == null && i < balls.Count)
            {
                if (balls[i].GetComponent<Ball>().active == false)
                {
                    availableBall = balls[i].GetComponent<Ball>();
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
                if (ball.GetComponent<Ball>().active)
                {
                    count++;
                }
            }
            return count;
        }
        public int CountNonActiveBall()
        {
            int count = 0;
            foreach (var ball in balls)
            {
                if (!ball.GetComponent<Ball>().active)
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