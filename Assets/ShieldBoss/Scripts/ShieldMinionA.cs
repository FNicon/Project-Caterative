using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using Caterative.Brick.Balls;

namespace Caterative.Brick.TheShieldBoss
{
    public class ShieldMinionA : MonoBehaviour, ICollidable
    {
        Shield shield;
        ShieldBossFigure figure;
        public int health = 10;
        public Ball targetBall;
        int redirectShieldCounter = 0;
        int stateCounter;
        public int stateLength = 3;

        void Awake()
        {
            shield = GetComponentInChildren<Shield>();
            figure = GetComponentInChildren<ShieldBossFigure>();
        }

        void Start()
        {
            shield.DirectTowards(225f);
        }

        void ICollidable.OnCollideWithBall(Ball ball)
        {
            targetBall = ball;
            health--;
            figure.Hit();
            AnnoyedMode(ball);
            if (health <= 0)
            {
                Deactivate();
            }
            stateCounter++;
        }

        private void Deactivate()
        {
            transform.position = new Vector2(-10, 100);
        }


        private void AnnoyedMode(Ball ball)
        {
            shield.setBoostDeflect(false);
            redirectShieldCounter = stateCounter % stateLength;
            if (redirectShieldCounter == stateLength - 1)
            {
                redirectShieldCounter = 0;
                RedirectShieldTowardsBall(ball);
            }

        }

        private void RedirectShieldTowardsBall(Ball incomingBall)
        {
            Vector2 ballRelativePos = incomingBall.transform.position - transform.position;
            float angleToRotate;
            if (ballRelativePos.x > 0)
            {
                if (ballRelativePos.y > 0)
                {
                    angleToRotate = 45f;
                }
                else
                {
                    angleToRotate = 315f;
                }
            }
            else
            {
                if (ballRelativePos.y > 0)
                {
                    angleToRotate = 135f;
                }
                else
                {
                    angleToRotate = 225f;
                }
            }
            shield.DirectTowards(angleToRotate, 0.1f);
        }
    }
}